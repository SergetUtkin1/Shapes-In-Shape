using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.Products.AbstractProducts
{
    public abstract class Shape
    {
        public Position Center { get; set; }
        public Dimension Dimension { get; set; }
        public double Volume { get; set; }

        public Shape(Position center, double length, double width, double heigth)
        {
            Dimension = new Dimension(length, width, heigth);
            Center = center;
            Volume = GetVolume();
        }

        protected abstract double GetVolume();
    }
}
