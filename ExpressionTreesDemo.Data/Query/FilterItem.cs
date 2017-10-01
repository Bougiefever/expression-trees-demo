using System;

namespace ExpressionTreesDemo.Data.Query
{
  public class FilterItem
  {
    public string FieldName { get; set; }
    public object Value { get; set; }
    public Type ValueType { get; set; }

    public FilterItem(string fieldName, object value, Type valueType)
    {
      FieldName = fieldName;
      Value = value;
      ValueType = valueType;
    }

    public FilterItem(string fieldName, object value)
    {
      FieldName = fieldName;
      Value = value;
      ValueType = value.GetType();
    }
  }
}