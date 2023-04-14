using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.AbstractProducts
{
    public abstract class Distribution
    {
        public abstract double GetValue(double minValue, double maxValue);
    }
}
