using System;
using System.Linq;

namespace ExpressionTreesDemo.Data.V1
{
  public class RepositoryV1 
  {
    private readonly Category[] _categories;
    private readonly Product[] _products;

    public IQueryable<Category> Categories => _categories.AsQueryable();

    public IQueryable<Product> Products => _products.AsQueryable();

    public RepositoryV1()
    {
      _categories = DemoHelper.Categories;
      _products = DemoHelper.Products;
    }

    public IQueryable<Product> DynamicFieldSelection(string field, string value)
    {
      IQueryable<Product> query;
      switch (field)
      {
        case "Id":
          query = _products.Where(product => product.Id == Convert.ToInt32(value)).AsQueryable();
          break;
        case "Category":
          query = _products
            .Where(product => product.CategoryType == (CategoryType) Enum.Parse(typeof(CategoryType), value))
            .AsQueryable();
          break;
        case "Name":
          query = _products.Where(product => product.Name == value).AsQueryable();
          break;
        default:
          query = _products.AsQueryable();
          break;
      }

      return query;
    }

    public IQueryable<Product> DynamicFieldSelectWithSortOption(string field, string value, string sortField)
    {
      IQueryable<Product> query;
      switch (field)
      {
        case "Id":
          query = Products.Where(product => product.Id == Convert.ToInt32(value));
          break;
        case "Category":
          query = _products
            .Where(product => product.Category.CategoryType == (CategoryType) Enum.Parse(typeof(CategoryType), value))
            .AsQueryable();
          break;
        case "Name":
          query = Products.Where(product => product.Name.Contains(value));
          break;
        default:
          query = Products;
          break;
      }

      switch (sortField)
      {
        case "Id":
          query = query.OrderBy(product => product.Id);
          break;
        case "Category":
          query = query.OrderBy(product => product.Category);
          break;
        case "Name":
          query = query.OrderBy(product => product.Name);
          break;
      }

      return query;
    }

    public IQueryable<Product> GetByCategory(CategoryType category)
    {
      return _products.Where(product => product.CategoryType == category).AsQueryable();
    }

    public Product GetById(int id)
    {
      return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product GetByName(string name)
    {
      return _products.FirstOrDefault(p => p.Name == name);
    }
  }
}