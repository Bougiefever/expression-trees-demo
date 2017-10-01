using System.Collections.Generic;
using ExpressionTreesDemo.Data.V2;

namespace ExpressionTreesDemo.V2.Web.Models
{
    public class CategorySelectionModel
    {
        public List<Category> Categories { get; set; } 
        public List<string> SelectedCategoryTypes { get; set; }
        public string SortOption { get; set; }
        public List<Product> Products { get; set; } 
    }
}