using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.Products.Shapes
{
    public class Sphere : Shape
    {
        public Sphere(Position center, double length, double width, double heigth) : base(center, length, width, heigth)
        {
            Dimension = new Dimension(length);
        }

        public Sphere(Position center, double length) : base(center, length)
        {

        }

        protected override double GetVolume()
        {
            double volume = (4.0 / 3.0) * double.Pi * Dimension.Length;
            return volume;
        }
    }
}
