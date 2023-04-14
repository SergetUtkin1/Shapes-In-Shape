using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.ConcreteFactories
{
    internal class SpheresInParallelepipedFactory : CaseFactory
    {
        private int _currentIndex = 0;
        public Sphere[] InnerShapes { get; set; }
        public Parallelepiped BoundingShape { get; set; }

        public SpheresInParallelepipedFactory(Sphere[] innerShapes, Parallelepiped boundingShape)
        {
            _currentIndex = 0;
            InnerShapes = innerShapes;
            BoundingShape = boundingShape;
        }

        public SpheresInParallelepipedFactory()
        {

        }

        public override Shape CreateBoundingShape(Dimension dimension)
        {
            BoundingShape = new Parallelepiped(new Position(), dimension.Length, dimension.Width, dimension.Heigth);
            return BoundingShape;
        }

        public override void CreateInnerShape(Position center, Dimension dimension)
        {
            var sphere = new Sphere(center, dimension.Length, dimension.Width, dimension.Heigth);
            InnerShapes[_currentIndex] = sphere;
        }

        public override bool CheckIntersection()
        {
            var flag = false;
            var sphere = InnerShapes[_currentIndex];

            if (HasIntersectionWithBound(sphere))
            {
                flag = true;
            }
            else
            {
                for (int i = 0; i < _currentIndex; i++)
                {
                    if (HasIntersectionWithOtherSphere(sphere, InnerShapes[i]))
                    {
                        flag = true;
                        break;
                    }
                }
            }

            return flag;
        }

        public override void SetCountOfInnerShapes(int count)
        {
            InnerShapes = new Sphere[count];
        }

        public override void Add()
        {
            _currentIndex += 1;
        }

        protected override bool HasIntersectionWithOtherSphere(Shape shape, Shape otherShape)
        {
            var flag = false;
            var distanceBetweenCenteres = shape.Center.GetDistance(otherShape.Center);

            if (distanceBetweenCenteres <= shape.Dimension.Length + otherShape.Dimension.Length)
            {
                flag = true;
            }

            return flag;
        }

        protected override bool HasIntersectionWithBound(Shape shape)
        {
            var flag = false;

            for (int i = 0; i < BoundingShape.Sides.Length; i++)
            {
                var distance = BoundingShape.Center.GetDistance(BoundingShape.Sides[i]);

                if (distance <= shape.Dimension.Length)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
    }
}
