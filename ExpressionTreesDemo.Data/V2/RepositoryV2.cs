using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionTreesDemo.Data.Query;

namespace ExpressionTreesDemo.Data.V2
{
  public class RepositoryV2 
  {
    public IQueryable<Product> Products
    {
      get { return _products.AsQueryable<Product>(); }
    }

    public IQueryable<Category> Categories
    {
      get { return _categories.AsQueryable(); }
    }

    public IQueryable<Product> DynamicFieldSelection(FilterItem filter)
    {
      ParameterExpression p = Expression.Parameter(typeof(Product), "p");
      MemberExpression fieldExpresion = Expression.PropertyOrField(p, filter.FieldName);
      ConstantExpression constantExpression = Expression.Constant(filter.Value, filter.ValueType);
      Expression compare = Expression.MakeBinary(ExpressionType.Equal, fieldExpresion, constantExpression);
      Expression<Func<Product, bool>> where = Expression.Lambda<Func<Product, bool>>(compare, new[] { p });
      var products = Products.Where(where);

      return products;
    }

    public IQueryable<Product> DynamicFieldSelectWithSortOption(FilterItem filter, string sortField)
    {
      var products = DynamicFieldSelection(filter);
      MethodInfo orderByMethodInfo = typeof(Queryable)
          .GetMethods(BindingFlags.Public | BindingFlags.Static)
              .Single(mi => mi.Name == "OrderBy"
              && mi.IsGenericMethodDefinition
              && mi.GetGenericArguments().Length == 2
              && mi.GetParameters().Length == 2);

      ParameterExpression p = Expression.Parameter(typeof(Product), "p");
      MemberExpression sortMember = Expression.PropertyOrField(p, sortField);
      Expression sortExpression = Expression.Lambda(sortMember, p);

      Type sortByPropType = typeof(Product).GetProperty(sortField).PropertyType;
      var sortedList = (orderByMethodInfo.MakeGenericMethod(new[] { typeof(Product), sortByPropType })
          .Invoke(products, new object[] { products, sortExpression }) as IOrderedQueryable<Product>);
      return sortedList;
    }

    public RepositoryV2()
    {
      _categories = DemoHelper.Categories;
      _products = DemoHelper.Products;
    }

    private readonly Category[] _categories;
    private readonly Product[] _products;
  }
}
