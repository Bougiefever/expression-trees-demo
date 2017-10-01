using System.ComponentModel;

namespace ExpressionTreesDemo.Data.V3
{
  public enum CategoryType
  {
    [Description("Car")] Car,
    [Description("Pet")] Pet,
    [Description("Cosmetics")] Cosmetics,
    [Description("Food")] Food,
    Green,
    Natural
  }
}