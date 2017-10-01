using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionTreesDemo.Data.Query;

namespace ExpressionTreesDemo.Data.V3
{
  public class RepositoryV3
  {
    public RepositoryV3()
    {
      _categories = DemoHelper.Categories;
      _products = DemoHelper.Products;
      _expressionBuilder = new LinqExpressionBuilder();
    }

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
      ParameterExpression p = _expressionBuilder.BuildParameterExpression<Product>("p");
      Expression compare = GetFieldComparison(filter, p);
      Expression<Func<Product, bool>> where = Expression.Lambda<Func<Product, bool>>(compare, new[] { p });
      var products = Products.Where(where);

      return products;
    }

    public IQueryable<Product> DynamicFieldSelection(FilterItem[] filterItems)
    {
      IList<Expression> expressions = new List<Expression>();
      ParameterExpression p = _expressionBuilder.BuildParameterExpression<Product>("p");
      foreach (var filterItem in filterItems)
      {
        //var expression = _expressionBuilder.BuildBinaryExpression(p, ExpressionType.Equal, filterItem);
        //var expression = GetFieldComparison(filterItem, p);
        var expression = ComplexFieldExpressionBuilder(filterItem, p);
        expressions.Add(expression);
      }

      Expression expressionGroup = _expressionBuilder.BuildExpressionOrGroup(expressions);

      Expression<Func<Product, bool>> where = _expressionBuilder.BuildLambdaExpression<Product, bool>(expressionGroup, p);
      var products = Products.Where(where);
      return products;
    }

    public Expression GetFieldExpression(FilterItem filter, ParameterExpression p)
    {
      Expression compare = GetFieldComparison(filter, p);
      return Expression.Lambda<Func<Product, bool>>(compare, new[] { p });
    }

    public IQueryable<Product> DynamicFieldSelectWithSortOption(FilterItem[] filterItems, SortItem sortItem)
    {
      var products = DynamicFieldSelection(filterItems);
      return GetOrderedList(products, sortItem);
    }

    private Expression GetFieldComparison(FilterItem filter, ParameterExpression p)
    {
      Expression e = filter.FieldName == "Name"
          ? _expressionBuilder.BuildContainsExpression(p, filter)
          : _expressionBuilder.BuildBinaryExpression(p, ExpressionType.Equal, filter);

      return e;
    }

    private Expression ComplexFieldExpressionBuilder(FilterItem filter, ParameterExpression p)
    {
      Expression e = null;
      switch (filter.FieldName)
      {
        case "Id":
        case "CategoryType":
        case "Name":
          e = GetFieldComparison(filter, p);
          break;
        case "Keyword":
          e = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", filter.Value));
          break;
        case "Color":
          e = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", filter.Value));
          break;
        case "Green":
        case "Natural":
          var natural = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", "natural"));
          var raw = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", "raw"));
          var pure = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", "pure"));
          var green = _expressionBuilder.BuildContainsExpression(p, new FilterItem("Description", "green"));
          var notFood = _expressionBuilder.BuildBinaryExpression(p, ExpressionType.NotEqual, new FilterItem("CategoryType", CategoryType.Food, typeof(CategoryType)));
          var orExpressions = _expressionBuilder.BuildExpressionOrGroup(new[] { natural, raw, pure, green });
          e = _expressionBuilder.BuildExpressionAndGroup(new[] { orExpressions, notFood });
          break;

      }

      return e;
    }

    private IOrderedQueryable<Product> GetOrderedList(IQueryable<Product> products, SortItem sortItem)
    {
      ParameterExpression p = _expressionBuilder.BuildParameterExpression<Product>("product");
      MethodInfo orderBy = DemoHelper.GetOrderByMethod(sortItem);
      MemberExpression sortMember = Expression.PropertyOrField(p, sortItem.SortField);
      Expression sortExpression = Expression.Lambda(sortMember, p);

      Type sortByPropType = typeof(Product).GetProperty(sortItem.SortField).PropertyType;
      var sortedList = (orderBy.MakeGenericMethod(new[] { typeof(Product), sortByPropType })
          .Invoke(products, new object[] { products, sortExpression }) as IOrderedQueryable<Product>);

      return sortedList;
    }

    private readonly Category[] _categories;
    private readonly Product[] _products;
    private ILinqExpressionBuilder _expressionBuilder;
  }
}
