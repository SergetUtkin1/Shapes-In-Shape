namespace ShapesInShape.Models.AbstractFactory.Products.AbstractProducts
{
    public abstract class Distribution
    {
        public abstract double GetValue(double minValue, double maxValue);
    }
}
