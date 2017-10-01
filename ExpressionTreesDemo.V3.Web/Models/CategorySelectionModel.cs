using System.Collections.Generic;
using ExpressionTreesDemo.Data.V3;

namespace ExpressionTreesDemo.V3.Web.Models
{
  public class CategorySelectionModel
  {
    public List<Category> Categories { get; set; }
    public List<string> SelectedCategoryTypes { get; set; }
    public string SortOption { get; set; }
    public List<Product> Products { get; set; }
    public string Keyword { get; set; }
    public string Color { get; set; }
  }
}