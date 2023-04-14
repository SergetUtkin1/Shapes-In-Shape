using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.AbstractFactory
{
    internal class Case
    {
        private CaseFactory Factory { get; set; }
        private int Count { get; set; }
        private Dimension BoundDimension { get; set; }
        private double MaxLength { get; set; }
        private double MinLength { get; set; }
        private Shape BoundingShape { get; set; }
        private Distribution DistributionOfPosition { get; set; }
        private Distribution DistributionOfLength { get; set; }

        public Case(CaseFactory factory, int count, Dimension boundDimension, double maxLength, double minLength, Distribution distributionOfPosition, Distribution distributionOfLength)
        {
            Factory = factory;
            BoundingShape = factory.CreateBoundingShape(boundDimension);
            Count = count;
            Factory.SetCountOfInnerShapes(count);
            BoundDimension = boundDimension;
            MaxLength = maxLength;
            MinLength = minLength;
            DistributionOfPosition = distributionOfPosition;
            DistributionOfLength = distributionOfLength;
        }

        public void Run()
        {
            var curCount = 0;
            var attemptCount = 0;

            while(curCount < Count && attemptCount < 10000)
            {
                var center = CreatePosition();
                var dimension = new Dimension()
                {
                    Length = CreateLength(),
                    Width = CreateLength(),
                    Heigth = CreateLength()
                };

                Factory.CreateInnerShape(center, dimension);

                if (Factory.CheckIntersection())
                {
                    attemptCount += 1;
                }
                else
                {
                    Factory.Add();
                    curCount += 1;
                    attemptCount = 0;
                }
            }
            Console.WriteLine(curCount);
        }

        private double CreateLength()
            => DistributionOfLength.GetValue(MinLength, MaxLength);

        private Position CreatePosition()
        {
            var x = DistributionOfPosition.GetValue(BoundingShape.Center.X - 0.5 * BoundDimension.Length, BoundingShape.Center.X + 0.5 * BoundDimension.Length);
            var y = DistributionOfPosition.GetValue(BoundingShape.Center.Y - 0.5 * BoundDimension.Width, BoundingShape.Center.Y + 0.5 * BoundDimension.Width);
            var z = DistributionOfPosition.GetValue(BoundingShape.Center.Z - 0.5 * BoundDimension.Heigth, BoundingShape.Center.Z + 0.5 * BoundDimension.Heigth);

            return new Position(x, y, z);
        }
    }
}
