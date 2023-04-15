using System;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.Products.Shapes
{
    public class Sphere : Shape
    {
        public Sphere(Position center, double length, double width, double heigth) : base(center, length, width, heigth)
        {
            Dimension = new Dimension(length);
        }

    }
}
