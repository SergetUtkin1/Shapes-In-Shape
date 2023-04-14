using MathNet.Numerics.Distributions;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.Distributions
{
    public class GaussianDistribution : Distribution
    {
        public override double GetValue(double minValue, double maxValue)
        {
            var dist = new Normal();
            return 0;
        }            
    }
}
