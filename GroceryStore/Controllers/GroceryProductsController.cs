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

        public async Task<IActionResult> Index(string category, string search)
        {
            if (await _context.GroceryProduct.CountAsync() == 0)
            {
                List<GroceryProductsModel> Produce = new List<GroceryProductsModel>();
                Produce.Add(new GroceryProductsModel { Name = "Tomatoe", ImagePath = "", Description = "", Price = 20.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new CategoryModel { Name = "Produce", GroceryProduct = Produce });

                List<GroceryProductsModel> Meat = new List<GroceryProductsModel>();
                Meat.Add(new GroceryProductsModel { Name = "Ground Beef", ImagePath = "", Description = "", Price = 20.99m, DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                _context.Categories.Add(new CategoryModel { Name = "Meat", GroceryProduct = Meat });

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
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Description.ToLowerInvariant().Contains(search.ToLowerInvariant()) || x.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList();
            }
            return View(model);
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