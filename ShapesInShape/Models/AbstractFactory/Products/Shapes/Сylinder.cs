using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.ConsoleApplication.Models.AbstractFactory.Products.Shapes
{
    public class Сylinder : Shape
    {
        public Сylinder(Position center, double length, double width, double heigth) : base(center, length, width, heigth)
        {
            Dimension = new Dimension()
            {
                Heigth = heigth,
                Length = length,
                Width = length
            };
        }

        public Сylinder(Position center, double length) : base(center, length)
        {

        }

        protected override double GetVolume()
        {
            double volume = Dimension.Length * double.Pi * Math.Pow(Dimension.Length, 2);
            return volume;
        }
    
    }
}
