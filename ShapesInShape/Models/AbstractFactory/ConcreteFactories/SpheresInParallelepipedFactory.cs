using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory.ConcreteFactories
{
    public class SpheresInParallelepipedFactory : CaseFactory
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

        public override void CreateBoundingShape(Dimension dimension) =>
            BoundingShape = new Parallelepiped(new Position(), dimension.Length, dimension.Width, dimension.Heigth);

        public override void CreateInnerShape(Position center, Dimension dimension)
        {
            var sphere = new Sphere(center, dimension.Length, dimension.Width, dimension.Heigth);
            InnerShapes[_currentIndex] = sphere;
        }

        public override void SetCountOfInnerShapes(int count)
        {
            InnerShapes = new Sphere[count];
        }

        public override Position CreatePosition(Distribution distributionOfPosition)
        {
            double x, y, z;
            Position position;

            do
            {
                x = distributionOfPosition.GetValue(BoundingShape.Center.X - 0.5 * BoundingShape.Dimension.Length, BoundingShape.Center.X + 0.5 * BoundingShape.Dimension.Length);
                y = distributionOfPosition.GetValue(BoundingShape.Center.Y - 0.5 * BoundingShape.Dimension.Width, BoundingShape.Center.Y + 0.5 * BoundingShape.Dimension.Width);
                z = distributionOfPosition.GetValue(BoundingShape.Center.Z - 0.5 * BoundingShape.Dimension.Heigth, BoundingShape.Center.Z + 0.5 * BoundingShape.Dimension.Heigth);
                position = new Position(x, y, z);
            } while (!CheckPointInsideBounding(position));

            return position;
        }

        protected override bool CheckPointInsideBounding(Position position)
        {
            var flag = false;
            var xPlanes = (BoundingShape.Center.X - 0.5 * BoundingShape.Dimension.Length, BoundingShape.Center.X + 0.5 * BoundingShape.Dimension.Length);
            var yPlanes = (BoundingShape.Center.Y - 0.5 * BoundingShape.Dimension.Width, BoundingShape.Center.Y + 0.5 * BoundingShape.Dimension.Width);
            var zPlanes = (BoundingShape.Center.Z - 0.5 * BoundingShape.Dimension.Heigth, BoundingShape.Center.Z + 0.5 * BoundingShape.Dimension.Heigth);

            var xCondition = (xPlanes.Item1 < position.X && position.X < xPlanes.Item2);
            var yCondition = (yPlanes.Item1 < position.Y && position.Y < yPlanes.Item2);
            var zCondition = (zPlanes.Item1 < position.Z && position.Z < zPlanes.Item2);
            if (xCondition && yCondition && zCondition)
            {
                flag = true;
            }

            return flag;
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

        public override void ConfirmAdding()
        {
            _currentIndex += 1;
        }
    }
}
