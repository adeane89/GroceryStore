using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Data;
using GroceryStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Controllers
{
    public class GroceryProductsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public GroceryProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index(string category)
        {
            if (await _context.GroceryProduct.CountAsync() == 0)
            {
                List<GroceryProductsModel> Produce = new List<GroceryProductsModel>();
                Produce.Add(new GroceryProductsModel { Name = "Tomato", ImagePath = "./images/tomato.jpg", Description = "", Price = 20.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new CategoryModel { Name = "Produce", GroceryProduct = Produce });

                List<GroceryProductsModel> Meat = new List<GroceryProductsModel>();
                Meat.Add(new GroceryProductsModel { Name = "Ground Beef", ImagePath = "./images/tomato.jpg", Description = "", Price = 19.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new CategoryModel { Name = "Meat", GroceryProduct = Meat });

                List<GroceryProductsModel> Seafood = new List<GroceryProductsModel>();
                Seafood.Add(new GroceryProductsModel { Name = "Seafood", ImagePath = "./images/tomato.jpg", Description = "", Price = 18.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new CategoryModel { Name = "Seafood", GroceryProduct = Seafood });

                await _context.SaveChangesAsync();
            }

            ViewBag.selectedCategory = category;
            List<GroceryProductsModel> model;
            if (string.IsNullOrEmpty(category))
            {
                model = await this._context.GroceryProduct.ToListAsync();
            }
            else
            {
                model = await this._context.GroceryProduct.Where(x => x.GroceryCategoryName == category).ToListAsync();
            }

            ViewData["Categories"] = await this._context.Categories.Select(x => x.Name).ToArrayAsync();

            
            return View(model);
        }

        public async Task<IActionResult> Details(int? id, int quantity, string category, string name, decimal price)
        {
            GroceryProductCart cart = null;
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                cart = await _context.GroceryProductCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ApplicationUserID == currentUser.Id);
                if (cart == null)
                {
                    cart = new GroceryProductCart();
                    cart.ApplicationUserID = currentUser.Id;
                    cart.DateCreated = DateTime.Now;
                    cart.DateLastModified = DateTime.Now;
                    _context.GroceryProductCart.Add(cart);
                }
            }
            else
            {
                if (Request.Cookies.ContainsKey("cart_id"))
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = await _context.GroceryProductCart.Include(x => x.GroceryCartProducts).FirstOrDefaultAsync(x => x.ID == existingCartID);
                }

                if (cart == null)
                {
                    cart = new GroceryProductCart
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now
                    };

                    _context.GroceryProductCart.Add(cart);
                }
            }

            GroceryCartProduct product = cart.GroceryCartProducts.FirstOrDefault(x => x.GroceryProductID == id);
            if (product == null)
            {
                product = new GroceryCartProduct
                {
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    GroceryProductID = id ?? 0,
                    Quantity = 0
                };

                cart.GroceryCartProducts.Add(product);
            }
            product.Quantity += quantity;
            product.DateLastModified = DateTime.Now;

            await _context.SaveChangesAsync();


            if (!User.Identity.IsAuthenticated)
            {
                Response.Cookies.Append("cart_id", cart.ID.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Produce()
        {
            return View();
        }

        public IActionResult Seafood()
        {
            return View();
        }

        public IActionResult Meat()
        {
            return View();
        }

        public IActionResult Bread()
        {
            return View();
        }

        public IActionResult Deli()
        {
            return View();
        }

        public IActionResult Beverages()
        {
            return View();
        }

        public IActionResult AlcoholicBeverages()
        {
            return View();
        }
    }
}