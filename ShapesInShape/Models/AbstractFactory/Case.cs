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
        private double Length { get; set; }
        private double MaxLength { get; set; }
        private double MinLength { get; set; }
        private Shape BoundingShape { get; set; }
        private Distribution DistributionOfPosition { get; set; }
        private Distribution DistributionOfLength { get; set; }

        public Case(CaseFactory factory, int count, double length, double maxLength, double minLength, Distribution distributionOfPosition, Distribution distributionOfLength)
        {
            Factory = factory;
            BoundingShape = factory.CreateBoundingShape(length);
            Count = count;
            Factory.SetCountOfInnerShapes(count);
            Length = length;
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
                var length = CreateLength();

                Factory.CreateInnerShape(center, length);

                if (Factory.CheckIntersection())
                {
                    attemptCount += 1;
                }
                else
                {
                    Factory.Add();
                    curCount += 1;
                    attemptCount = 0;
                    Console.WriteLine($"Окружность номер {curCount}: ({center.X}, {center.Y}, {center.Z}) R = {length} " );
                }
            }
            Console.WriteLine(curCount);
        }

        private double CreateLength() =>
            DistributionOfLength.GetValue(MinLength, MaxLength);

        private Position CreatePosition()
        {
            var x = DistributionOfPosition.GetValue(BoundingShape.Center.X - 0.5 * Length, BoundingShape.Center.X + 0.5 * Length);
            var y = DistributionOfPosition.GetValue(BoundingShape.Center.Y - 0.5 * Length, BoundingShape.Center.Y + 0.5 * Length);
            var z = DistributionOfPosition.GetValue(BoundingShape.Center.Z - 0.5 * Length, BoundingShape.Center.Z + 0.5 * Length);

            return new Position(x, y, z);
        }
    }
}
