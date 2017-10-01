using System.ComponentModel;

namespace ExpressionTreesDemo.Data.V2
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get { return Category.Id; } }
        public CategoryType CategoryType { get { return Category.CategoryType; } }
        public Category Category { get; set; }
        public string Description { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Name
        {
            get { return CategoryType.ToString(); }
        }
        public CategoryType CategoryType { get; set; }
    }

    public enum CategoryType
    {
        [Description("Car")]
        Car,
        [Description("Pet")]
        Pet,
        [Description("Cosmetics")]
        Cosmetics,
        [Description("Food")]
        Food
    }
}
