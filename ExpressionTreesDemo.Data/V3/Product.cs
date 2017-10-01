namespace ExpressionTreesDemo.Data.V3
{
  public class Product
  {
    public Category Category { get; set; }
    public int CategoryId => Category.Id;
    public CategoryType CategoryType => Category.CategoryType;
    public string Description { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
  }
}