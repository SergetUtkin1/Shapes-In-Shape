using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.ConcreteFactories
{
    public class SphereInSphereFactory : CaseFactory
    {
        public Sphere[] InnerShapes { get; set; } = null!;
        public Sphere BoundingShape { get; set; } = null!;

        public override bool CheckIntersection()
        {
            throw new NotImplementedException();
        }

        public override void ConfirmAdding()
        {
            throw new NotImplementedException();
        }

        public override void CreateBoundingShape(Dimension dimension)
        {
            throw new NotImplementedException();
        }

        public override void CreateInnerShape(Position center, Dimension dimension)
        {
            throw new NotImplementedException();
        }

        public override Position CreatePosition(Distribution distributionOfPosition)
        {
            throw new NotImplementedException();
        }

        public override Shape[] GetArrayOfInnerShapes(Dimension[] dimensions)
        {
            throw new NotImplementedException();
        }

        public override void SetCountOfInnerShapes(int count)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckPointInsideBounding(Position position)
        {
            throw new NotImplementedException();
        }

        protected override bool HasIntersectionWithBound(Shape shape)
        {
            throw new NotImplementedException();
        }

        protected override bool HasIntersectionWithOtherSphere(Shape shape, Shape otherShape)
        {
            throw new NotImplementedException();
        }
    }
}
