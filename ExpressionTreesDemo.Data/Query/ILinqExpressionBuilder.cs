using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreesDemo.Data.Query
{
    public interface ILinqExpressionBuilder
    {
        BinaryExpression BuildBinaryExpression(ParameterExpression parameter, ExpressionType expressionType, FilterItem item);
        Expression<Func<T, TFunc>> BuildLambdaExpression<T, TFunc>(Expression expression, ParameterExpression parameter);
        Expression<Func<T1, T2, TResult>> BuildLambdaExpression<T1, T2, TResult>(Expression expression, ParameterExpression p1, ParameterExpression p2);
        Expression BuildExpressionOrGroup(IEnumerable<Expression> expressions);
        Expression BuildExpressionAndGroup(IEnumerable<Expression> expressions);
        UnaryExpression BuildNotExpression(Expression expression);
        UnaryExpression BuildConvertExpression(Expression expression, Type convertTo);
        ParameterExpression BuildParameterExpression<T>(string parameter);
        Expression BuildContainsExpression(ParameterExpression parameter, FilterItem item);
        Expression BuildWhereExpression<T>(Expression sourceExpression, Expression whereExpression);

        Expression BuildJoinExpression<TOuter, TInner, TKey, TResult>(
            Expression outerExpression,
            Expression innerExpression,
            Expression<Func<TOuter, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<TOuter, TInner, TResult>> resultSelector);

        MemberExpression BuildPropertyExpression(ParameterExpression parameter, string propertyName);
        
        ConstantExpression BuildConstantExpression(object value, Type type);
    }
}