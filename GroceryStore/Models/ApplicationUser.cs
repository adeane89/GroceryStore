using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GroceryStore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            this.GroceryProductCart = new GroceryProductCart();
        }

        public ApplicationUser(string userName) : base(userName)
        {
            this.GroceryProductCart = new GroceryProductCart();
        }

        public GroceryProductCart GroceryProductCart { get; set; }
        public int GroceryProductCartID { get; set; }
    }
}
