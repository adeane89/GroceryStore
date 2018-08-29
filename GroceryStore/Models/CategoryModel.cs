using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            this.GroceryProduct = new HashSet<GroceryProductsModel>();
        }
        public string Name { get; set; }
        public ICollection<GroceryProductsModel> GroceryProduct { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
