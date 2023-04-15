using MathNet.Numerics.Distributions;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;

namespace ShapesInShape.Models.AbstractFactory.Products.Distributions
{
    public class GaussianDistribution : Distribution
    {
        public override double GetValue(double minValue, double maxValue)
        {
            var dist = new Normal();
            return minValue + (maxValue - minValue) * dist.Sample();
        }            
    }
}
