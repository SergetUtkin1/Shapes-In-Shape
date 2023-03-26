using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.AbstractProducts
{
    internal abstract class Shape
    {
        public Position Center { get; set; }

        public Shape(Position center)
        {
            Center = center;
        }
    }
}
