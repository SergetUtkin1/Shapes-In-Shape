using ShapesInShape.Models.AbstractFactory;
using ShapesInShape.Models.AbstractFactory.ConcreteFactories;
using ShapesInShape.Models.AbstractFactory.Products.Distributions;
using ShapesInShape.Models.AbstractFactory.Products.Shapes;
using ShapesInShape.Models.BasicElements;

internal class Program
{
    private static void Main()
    {
        //var factory = new SpheresInParallelepipedFactory();
        //var distribution = new UniformDistribution();
        //var myCase = new Case(factory, 1000, new Dimension(200, 200, 200), 100, 20, distribution, distribution);
        //myCase.Run();
        for (int i = 0; i < 100; i++)
        {
            var rnd = new GaussianDistribution();
            Console.WriteLine(rnd.GetValue(0,1));
        }
    }
}