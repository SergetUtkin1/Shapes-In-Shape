using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;
using System;
using System.Collections.Generic;
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
        private Shape InnerShape { get; set; }
        private Distribution DistributionOfPosition { get; set; }
        private Distribution DistributionOfLength { get; set; }

        public Case(CaseFactory factory, double length)
        {
            Factory = factory;
            BoundingShape = factory.CreateBoundingShape(length);
            Length = length;
        }

        public void Run()
        {
            var center = CreatePosition();
            var length = CreateLength();
            InnerShape = Factory.CreateInnerShape(center, length);
        }

        private double CreateLength() =>
            DistributionOfPosition.GetValue(MinLength, MaxLength);

        private Position CreatePosition()
        {
            var x = DistributionOfPosition.GetValue(BoundingShape.Center.X - 0.5 * Length, BoundingShape.Center.X + 0.5 * Length);
            var y = DistributionOfPosition.GetValue(BoundingShape.Center.Y - 0.5 * Length, BoundingShape.Center.Y + 0.5 * Length);
            var z = DistributionOfPosition.GetValue(BoundingShape.Center.Z - 0.5 * Length, BoundingShape.Center.Z + 0.5 * Length);

            return new Position(x, y, z);
        }
    }
}
