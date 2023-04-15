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
    public abstract class CaseFactory
    {
        protected int _currentIndex = 0;
        public abstract void SetCountOfInnerShapes(int count);
        public abstract void ConfirmAdding();
        public abstract void CreateBoundingShape(Dimension dimension);
        public abstract void CreateInnerShape(Position center, Dimension dimension);
        public abstract bool CheckIntersection();
        public abstract Position CreatePosition(Distribution distributionOfPosition);
        protected abstract bool CheckPointInsideBounding(Position position);
        protected abstract bool HasIntersectionWithOtherSphere(Shape shape, Shape otherShape);
        protected abstract bool HasIntersectionWithBound(Shape shape);
    }
}
