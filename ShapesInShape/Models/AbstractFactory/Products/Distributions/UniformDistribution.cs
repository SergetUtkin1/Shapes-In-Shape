using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;

namespace ShapesInShape.Models.AbstractFactory.Products.Distributions
{
    public class UniformDistribution : Distribution
    {
        public override double GetValue(double minValue, double maxValue) =>
            minValue + (maxValue - minValue) * Random.Shared.NextDouble();
    }
}
