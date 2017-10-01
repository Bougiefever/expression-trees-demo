using System.Collections.Generic;
using ExpressionTreesDemo.Data.V1;

namespace ExpressionTreesDemo.Web.Models
{
  public class NameSelectionModel
  {
    public List<Product> Products { get; set; }
    public string SelectedName { get; set; }
    public string SortOption { get; set; }
  }
}