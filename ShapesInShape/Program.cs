using ShapesInShape.Models.AbstractFactory;
using ShapesInShape.Models.AbstractFactory.ConcreteFactories;
using ShapesInShape.Models.AbstractFactory.Products.Distributions;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;

internal class Program
{
    private static void Main()
    {
        var factory = new SpheresInCubeFactory();
        var distribution = new UniformDistribution();
        var myCase = new Case(factory, 1000, 200, 100, 20, distribution, distribution);
        myCase.Run();
    }
}