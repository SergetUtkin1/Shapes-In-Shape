using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory
{
    internal abstract class CaseFactory
    {
        public abstract void SetCountOfInnerShapes(int count);
        public abstract void Add();
        public abstract Shape CreateBoundingShape(Dimension dimension);
        public abstract void CreateInnerShape(Position center, Dimension dimension);
        public abstract bool CheckIntersection();
        protected abstract bool HasIntersectionWithOtherSphere(Shape shape, Shape otherShape);
        protected abstract bool HasIntersectionWithBound(Shape shape);
    }
}
