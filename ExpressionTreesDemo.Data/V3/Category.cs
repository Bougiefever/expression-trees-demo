namespace ExpressionTreesDemo.Data.V3
{
  public class Category
  {
    public CategoryType CategoryType { get; set; }
    public int Id { get; set; }

    public string Name => CategoryType.ToString();
  }
}