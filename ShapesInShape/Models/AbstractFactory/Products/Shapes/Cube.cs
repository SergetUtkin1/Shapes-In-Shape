using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory.Products.Shapes
{
    internal class Cube : Shape
    {

        public Plane[] Sides { get; private set; }

        public Position[] Points { get; private set; }

        public double EdgeLength { get; }

        public Cube(Position center, double length) : base(center)
        {
            EdgeLength = length;
            Sides = new Plane[6];
            Points = new Position[8];
            SetSides();
        }

        private void SetSides()
        {
            var PointsOfSides = GetPointsOfSides();

            for (int j = 0; j < 3; j++)
            {
                var PointsOfTwoSides = new List<Position>();
                var i = 0;
                while (i < PointsOfSides.Count)
                {
                    var index = i + j;

                    PointsOfTwoSides.Add(PointsOfSides[index]);

                    i += 3;
                }
                Points = PointsOfTwoSides.ToArray();

                Sides[j] = new Plane(PointsOfTwoSides[0], PointsOfTwoSides[1], PointsOfTwoSides[2], PointsOfTwoSides[3]);
                Sides[Sides.Length - 1 - j] = new Plane(PointsOfTwoSides[4], PointsOfTwoSides[5], PointsOfTwoSides[6], PointsOfTwoSides[7]);
            }
        }

        private List<Position> GetPointsOfSides()
        {
            var temp = new int[2] { -1, 1 };
            var PointsOfSides = new List<Position>();

            foreach (var i in temp)
            {
                foreach (var j in temp)
                {
                    foreach (var k in temp)
                    {
                        var tempArray = new int[] { i, j, k };

                        var x = Center.X + tempArray[0] * EdgeLength * 0.5;
                        var y = Center.Y + tempArray[1] * EdgeLength * 0.5;
                        var z = Center.Z + tempArray[2] * EdgeLength * 0.5;

                        PointsOfSides.Add(new Position(x, y, z));

                        x = Center.X + tempArray[1] * EdgeLength * 0.5;
                        y = Center.Y + tempArray[0] * EdgeLength * 0.5;
                        z = Center.Z + tempArray[2] * EdgeLength * 0.5;

                        PointsOfSides.Add(new Position(x, y, z));

                        x = Center.X + tempArray[2] * EdgeLength * 0.5;
                        y = Center.Y + tempArray[1] * EdgeLength * 0.5;
                        z = Center.Z + tempArray[0] * EdgeLength * 0.5;

                        PointsOfSides.Add(new Position(x, y, z));

                    }
                    temp = temp.Reverse().ToArray();
                }
            }

            return PointsOfSides;
        }
    }
}
