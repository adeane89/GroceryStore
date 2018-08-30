using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryProductsModel
    {
        public GroceryProductsModel()
        {
            this.GroceryCartProducts = new HashSet<GroceryCartProduct>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string GroceryCategoryName { get; set; }
        public CategoryModel Category { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<GroceryCartProduct> GroceryCartProducts { get; set; }
    }
}
