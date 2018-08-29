using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryCartProduct
    {
        public int GroceryCartProductID { get; set; }
        public GroceryProductCart GroceryProductCart { get; set; }
        public GroceryProductsModel GroceryProducts { get; set; }
        public int GroceryProductID { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
