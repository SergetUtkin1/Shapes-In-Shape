using ShapesInShape.ConsoleApplication.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.ConsoleApplication.Utils;
using ShapesInShape.Models.AbstractFactory;
using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.ConsoleApplication.Models.AbstractFactory.ConcreteFactories
{
    public class CylinderInParallelepipedFactory : CaseFactory
    {
        public Cylinder[] InnerShapes { get; set; } = null!;
        public Parallelepiped BoundingShape { get; set; } = null!;

        public override void CreateBoundingShape(Dimension dimension) =>
            BoundingShape = new Parallelepiped(new Position(), dimension.Length, dimension.Width, dimension.Heigth);

        public override void CreateInnerShape(Position center, Dimension dimension)
        {
            var сylinder = new Cylinder(center, dimension.Length, dimension.Width, dimension.Heigth, dimension.Theta, dimension.Fi);
            InnerShapes[_currentIndex] = сylinder;
        }
       
        public override void SetCountOfInnerShapes(int count)
        {
            InnerShapes = new Cylinder[count];
        }

        public override Position CreatePoint(Distribution distributionOfPosition)
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

        public override Shape[] GetArrayOfInnerShapes(Dimension[] dimensions, bool isSortingEnable)
        {
            var spheres = new Cylinder[dimensions.Length];

            for (int i = 0; i < dimensions.Length; i++)
            {
                spheres[i] = new Cylinder(new Position(),
                                        dimensions[i].Length,
                                        dimensions[i].Width,
                                        dimensions[i].Heigth,
                                        dimensions[i].Theta,
                                        dimensions[i].Fi);
            }

            if (isSortingEnable)
                Array.Sort(spheres, (a, b) => ((int)(b.Volume - a.Volume)));

            return spheres;
        }

        public override bool CheckIntersection()
        {
            throw new NotImplementedException();
        }

        protected override bool HasIntersectionWithBound(Shape shape)
        {
            throw new NotImplementedException();
        }

        protected override bool HasIntersectionWithOtherShape(Shape shape, Shape otherShape)
        {
            throw new NotImplementedException();
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

        private (List<double> xPoints, List<double> yPoints, List<double> zPoints) GetSurfCylinder(double diametr, double height, int amount = 100)
        {
            var radius = diametr * 0.5;
            var area = Math.PI * (2 * Math.Pow(radius, 2) + 2 * radius * height);
            var dimensionOfElemntarySurf = area / amount;
            var cntOfBasePoints = Math.Floor(Math.PI * Math.Pow(radius, 2 / dimensionOfElemntarySurf));
            var cntOfRadiusPoints = (int)Math.Floor(Math.Sqrt(cntOfBasePoints));
            var cntOfBoundPoints = Math.Floor(2 * Math.PI * radius * height / dimensionOfElemntarySurf);
            var radiusesOfBase = MathHelper.GetLinSpace(radius / cntOfRadiusPoints, radius, cntOfRadiusPoints);
            var Vox1 = new List<double>();
            var Voy1 = new List<double>();
            var Voz1 = new List<double>();

            foreach (var radiusOfBase in radiusesOfBase)
            {
                var Nf = (int)Math.Round(2 * cntOfRadiusPoints * radiusOfBase / radius);
                var radiusesOfInnerPointsOfBase = MathHelper.GetLinSpace(0, 2 * Math.PI, Nf);
                foreach (var innerRadius in radiusesOfInnerPointsOfBase)
                {
                    Vox1.Append(radiusOfBase * Math.Cos(innerRadius));
                    Voy1.Append(radiusOfBase * Math.Sin(innerRadius));
                    Voz1.Append(height * 0.5);
                }
            }

            var NF = (int)(2 * cntOfRadiusPoints);
            var Nh = (int)(Math.Floor(0.5 * cntOfBoundPoints / NF));
            var F = MathHelper.GetLinSpace(0.0, 2 * Math.PI, NF);
            var h = MathHelper.GetLinSpace(0.25 * height, 0.5 - 0.5 * height / Nh, Nh);
            var Vox2 = Enumerable.Repeat(0.0, NF * Nh).ToList();
            var Voy2 = Enumerable.Repeat(0.0, NF * Nh).ToList();
            var Voz2 = Enumerable.Repeat(0.0, NF * Nh).ToList();
            var iFh = Enumerable.Range(0, NF * Nh);
            for (int i = 0; i < iFh.Count(); i++)
            {
                Vox2[i] = radius * Math.Cos(F[i - NF * (i / NF)]);
                Voy2[i] = radius * Math.Sin(F[i - NF * (i / NF)]);
                Voz2[i] = h[i / NF];
            }
            var Vox12 = Enumerable.Concat(Vox1, Vox2).ToList();
            var Voy12 = Enumerable.Concat(Voy1, Voy2).ToList();
            var Voz12 = Enumerable.Concat(Voz1, Voz2).ToList();

            var Vox = Enumerable.Concat(Vox12, Vox12).ToList();
            var Voy = Enumerable.Concat(Voy12, Voy12).ToList();
            var Voz = Enumerable.Concat(Voz12, Voz12).ToList();

            Console.WriteLine($"обшее количество точек  на поверхности = {Vox.Count}");
            return (Vox, Voy, Voz);
        }
    }
}
