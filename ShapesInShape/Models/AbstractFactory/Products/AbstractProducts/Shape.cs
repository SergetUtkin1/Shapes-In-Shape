using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.AbstractProducts
{
    public abstract class Shape
    {
        public Position Center { get; set; }

        public Dimension Dimension { get; set; }

        public Shape(Position center, double length, double width, double heigth)
        {
            Dimension = new Dimension(length, width, heigth);
            Center = center;
        }
    }
}
