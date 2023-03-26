using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.Distributions
{
    internal class UniformDistribution : Distribution
    {
        public override double GetValue(double minValue, double maxValue) =>
            minValue + (maxValue - minValue) * Random.Shared.NextDouble();
    }
}
