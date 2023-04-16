using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models.AbstractFactory
{
    public class Case
    {
        private Shape[] _shapes;
        private CaseConfiguration Configuration { get; set; }
        private CaseFactory Factory { get; set; }

        public Case(CaseFactory factory, CaseConfiguration configuration)
        {
            Configuration = configuration;
            Factory = factory;
            Factory.CreateBoundingShape(Configuration.BoundDimension);
            Factory.SetCountOfInnerShapes(Configuration.Count);
            _shapes = FillArrayOfInnerShapes();
        }

        public void Run()
        {
            var curCount = 0;
            var attemptCount = 0;
            var shapeIndex = 0;

            while (curCount < Configuration.Count && attemptCount < 1000000000 && shapeIndex < _shapes.Length - 1)
            {
                if (attemptCount > 10000000)
                    shapeIndex += 1;

                var center = Factory.CreatePoint(Configuration.DistributionOfPosition); 
                Factory.CreateInnerShape(center, _shapes[shapeIndex].Dimension);

                if (Factory.CheckIntersection())
                {
                    attemptCount += 1;
                }
                else
                {
                    Factory.ConfirmAdding();
                    curCount += 1;
                    shapeIndex += 1;
                    attemptCount = 0;
                    Console.WriteLine($"Окружность номер {curCount}: ({center.X}, {center.Y}, {center.Z}) R = {_shapes[shapeIndex].Dimension.Length} ");
                }
            }
            Console.WriteLine($"Удалось вместить: {curCount}. \nПройдено фигур: {shapeIndex}");
        }

        private Shape[] FillArrayOfInnerShapes()
        {
            var count = Configuration.Count;
            var dimensions = new Dimension[count];

            for (int i = 0; i < count; i++)
            {
                var dimension = new Dimension()
                {
                    Length = CreateLength(),
                    Width = CreateLength(),
                    Heigth = CreateLength()
                };
                dimensions[i] = dimension;
            }
            var shapes = Factory.GetArrayOfInnerShapes(dimensions);

            return shapes;
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
