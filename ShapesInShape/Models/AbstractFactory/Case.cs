using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory
{
    internal class Case
    {
        private CaseConfiguration Configuration { get; set; }
        private CaseFactory Factory { get; set; }

        public Case(CaseFactory factory, CaseConfiguration configuration)
        {
            Configuration = configuration;
            Factory = factory;
            Factory.CreateBoundingShape(Configuration.BoundDimension);
            Factory.SetCountOfInnerShapes(Configuration.Count);
        }

        public void Run()
        {
            var curCount = 0;
            var attemptCount = 0;

            while (curCount < Configuration.Count && attemptCount < 10000)
            {
                var center = Factory.CreatePosition(Configuration.DistributionOfPosition);
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
                    Factory.ConfirmAdding();
                    curCount += 1;
                    attemptCount = 0;
                    Console.WriteLine($"Окружность номер {curCount}: ({center.X}, {center.Y}, {center.Z}) R = {dimension.Length} ");
                }
            }
            Console.WriteLine(curCount);
        }

        private double CreateLength()
        {
            double length;

            do
            {
                length = Configuration.DistributionOfLength
                        .GetValue(Configuration.MinLength, Configuration.MaxLength);
            } while (!(Configuration.MinLength <= length && length <= Configuration.MaxLength));

            return length;
        }
           

    }
}
