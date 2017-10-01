using System.Collections.Generic;
using ExpressionTreesDemo.Data.V1;

namespace ExpressionTreesDemo.Web.Models
{
  public class IdSelectionModel
  {
    public List<Product> Products { get; set; }
    public int SelectedId { get; set; }
    public string SortOption { get; set; }
  }
}