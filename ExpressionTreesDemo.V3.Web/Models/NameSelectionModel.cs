using System.Collections.Generic;
using ExpressionTreesDemo.Data.V3;

namespace ExpressionTreesDemo.V3.Web.Models
{
    public class NameSelectionModel
    {
        public string SelectedName { get; set; }
        public List<Product> Products { get; set; }
        public string SortOption { get; set; }
    }
}