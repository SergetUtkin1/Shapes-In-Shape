using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory
{
    internal abstract class CaseFactory
    {
        public abstract Shape CreateBoundingShape(double length);
        public abstract Shape CreateBoundingShape(double length, double width, double height);
        public abstract Shape CreateInnerShape(Position center, double length);

    }
}
