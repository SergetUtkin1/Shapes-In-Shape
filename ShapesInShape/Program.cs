using ShapesInShape.Models;
using ShapesInShape.Models.AbstractFactory;
using ShapesInShape.Models.AbstractFactory.ConcreteFactories;
using ShapesInShape.Models.AbstractFactory.Products.Distributions;
using ShapesInShape.Models.BasicElements;

internal class Program
{
    private static void Main()
    {
        var factory = new SphereInSphereFactory();
        var configuration = new CaseConfiguration()
        {
            Count = 1000,
            BoundDimension = new Dimension(200, 200, 200),
            MaxLength = 25,
            MinLength = 20,
            DistributionOfLength = new UniformDistribution(),
            DistributionOfPosition = new UniformDistribution()
        };

        var myCase = new Case(factory, configuration);

        myCase.Run();
    }
}