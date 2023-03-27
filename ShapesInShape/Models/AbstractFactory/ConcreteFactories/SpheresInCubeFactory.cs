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
        public int CurrentIndex { get; set; } = 0;
        public Sphere[] InnerShapes { get; set; }
        public Cube BoundingShape { get; set; }
        public override Shape CreateBoundingShape(double length)
        {
            BoundingShape = new Cube(new Position(), length);
            return BoundingShape;
        }

        public override void CreateInnerShape(Position center, double length)
        {
            var sphere = new Sphere(center, length);
            InnerShapes[CurrentIndex] = sphere;
        }

        public override bool CheckIntersection()
        {
            var flag = false;
            var sphere = InnerShapes[CurrentIndex];

            if (HasIntersectionWithBound(sphere))
            {
                flag = true;
            }
            else
            {
                for (int i = 0; i < CurrentIndex; i++)
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

        private bool HasIntersectionWithOtherSphere(Sphere sphere, Sphere otherSphere)
        {
            var flag = false;
            var distanceBetweenCenteres = sphere.Center.GetDistance(otherSphere.Center);

            if (distanceBetweenCenteres <= sphere.Radius + otherSphere.Radius)
            {
                flag = true;
            }

            return flag;
        }

        private bool HasIntersectionWithBound(Sphere sphere)
        {
            var flag = false;

            for (int i = 0; i < BoundingShape.Sides.Length; i++)
            {
                var distance = BoundingShape.Center.GetDistance(BoundingShape.Sides[i]);

                if (distance <= sphere.Radius)
                {
                    flag = true;
                    break;
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
            CurrentIndex += 1;
        }
    }
}
