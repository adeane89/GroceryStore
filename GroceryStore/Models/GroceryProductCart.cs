using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryProductCart
    {
        public GroceryProductCart()
        {
            this.GroceryCartProducts = new HashSet<GroceryCartProduct>();
        }

        public GroceryProductsModel GroceryProducts { get; set; }

        public int ID { get; set; }
        public ICollection<GroceryCartProduct> GroceryCartProducts { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
