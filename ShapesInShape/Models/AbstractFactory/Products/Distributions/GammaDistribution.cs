using MathNet.Numerics.Distributions;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;

namespace ShapesInShape.Models.AbstractFactory.Products.Distributions
{
    public class GammaDistribution : Distribution
    {
        public override double GetValue(double minValue, double maxValue)
        {
            var dist = new Gamma(0.5, 1);
            return (double)(minValue + (maxValue - minValue) * dist.Sample());
        }
    }
}
