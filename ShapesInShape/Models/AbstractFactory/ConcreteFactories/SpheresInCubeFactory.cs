using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.ConcreteFactories
{
    internal class SpheresInCubeFactory : CaseFactory
    {
        public override Shape CreateBoundingShape(double length)
        {
            return new Cube(new Position(), length);
        }

        public override Shape CreateBoundingShape(double length, double width, double height)
        {
            throw new NotImplementedException();
        }

        public override Shape CreateInnerShape(Position center, double length)
        {
            throw new NotImplementedException();
        }
    }
}
