using System;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.Products.Shapes
{
    internal class Sphere : Shape
    {
        public double Radius { get; set; }

        public Sphere(Position center, double radius) : base(center)
        {
            Radius = radius;
        }
    }
}
