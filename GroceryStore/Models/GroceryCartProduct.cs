using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryCartProduct
    {
        public int ID { get; set; }
        public GroceryProductCart GroceryProductCart { get; set; }
        public int GroceryCartProductID { get; set; }
        public GroceryProductsModel GroceryProducts { get; set; }
        public int GroceryProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

    }
}
