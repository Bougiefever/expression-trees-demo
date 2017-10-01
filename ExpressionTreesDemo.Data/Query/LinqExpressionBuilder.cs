using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionTreesDemo.Data.Query
{
    /// <summary>
    /// Builds linq query expressions
    /// </summary>
    public class LinqExpressionBuilder : ILinqExpressionBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="expressionType"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public BinaryExpression BuildBinaryExpression(ParameterExpression parameter, ExpressionType expressionType, FilterItem item)
        {
            BinaryExpression comparison = Expression.MakeBinary(
                expressionType,
                BuildPropertyExpression(parameter, item.FieldName),
                BuildConstantExpression(item.Value, item.ValueType));
            return comparison;
        }

        public Expression<Func<T, TFunc>> BuildLambdaExpression<T, TFunc>(Expression expression, ParameterExpression parameter)
        {
            return Expression.Lambda<Func<T, TFunc>>(expression, new[] {parameter});
        }

        public Expression<Func<T1, T2, TResult>> BuildLambdaExpression<T1, T2, TResult>(Expression expression, ParameterExpression p1, ParameterExpression p2)
        {
            return Expression.Lambda<Func<T1, T2, TResult>>(expression, new[] {p1, p2});
        }

        public Expression BuildExpressionOrGroup(IEnumerable<Expression> expressions)
        {
            return expressions.Aggregate<Expression, Expression>(null, (current, expression) => current == null ? expression : Expression.OrElse(current, expression));
        }

        public Expression BuildExpressionAndGroup(IEnumerable<Expression> expressions)
        {
            return expressions.Aggregate<Expression, Expression>(null, (current, expression) => current == null ? expression : Expression.AndAlso(current, expression));
        }

        public UnaryExpression BuildNotExpression(Expression expression)
        {
            return Expression.Not(expression);
        }

        public UnaryExpression BuildConvertExpression(Expression expression, Type convertTo)
        {
            UnaryExpression convertedExpression = Expression.Convert(expression, convertTo);
            return convertedExpression;
        }

        public ParameterExpression BuildParameterExpression<T>(string parameter)
        {
            return Expression.Parameter(typeof (T), parameter);
        }

        public Expression BuildContainsExpression(ParameterExpression parameter, FilterItem item)
        {
            MethodInfo containsMethod = typeof (string).GetMethod("Contains");
            MethodCallExpression contains = Expression.Call(BuildPropertyExpression(parameter, item.FieldName), containsMethod, new[] {BuildConstantExpression(item.Value, item.ValueType)});
            return contains;
        }

        public Expression BuildWhereExpression<T>(Expression sourceExpression, Expression whereExpression)
        {
            MethodInfo whereMethod = typeof (Queryable).GetMethods().Single(m => m.ToString() == "System.Linq.IQueryable`1[TSource] Where[TSource](System.Linq.IQueryable`1[TSource], System.Linq.Expressions.Expression`1[System.Func`2[TSource,System.Boolean]])");
            MethodInfo genericWhere = whereMethod.MakeGenericMethod(new[] {typeof (T)});
            MethodCallExpression expression = Expression.Call(genericWhere, new[] {sourceExpression, whereExpression});
            return expression;
        }

        public Expression BuildJoinExpression<TOuter, TInner, TKey, TResult>(
            Expression outerExpression,
            Expression innerExpression,
            Expression<Func<TOuter, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            MethodInfo joinMethod = typeof (Queryable).GetMethods().Where(m => m.Name == "Join").Single(m => m.GetParameters().Count() == 5);
            MethodInfo joinMethodGeneric = joinMethod.MakeGenericMethod(new[] {typeof (TOuter), typeof (TInner), typeof (TKey), typeof (TResult)});

            MethodCallExpression joinExpression = Expression.Call(joinMethodGeneric, new[] {outerExpression, innerExpression, outerKeySelector, innerKeySelector, resultSelector});
            return joinExpression;
        }

        public MemberExpression BuildPropertyExpression(ParameterExpression parameter, string propertyName)
        {
            MemberExpression propertyExpression = Expression.Property(parameter, propertyName);
            return propertyExpression;
        }

        public ConstantExpression BuildConstantExpression(object value, Type type)
        {
            ConstantExpression constantExpression = Expression.Constant(value, type);
            return constantExpression;
        }
    }

    // http://www.patheos.com/blogs/friendlyatheist/2011/02/07/name-something-that-gets-passed-around/
}