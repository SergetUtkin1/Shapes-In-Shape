using ShapesInShape.ConsoleApplication.Models.AbstractFactory.ConcreteFactories;
using ShapesInShape.ConsoleApplication.Utils;
using ShapesInShape.Models;
using ShapesInShape.Models.AbstractFactory;
using ShapesInShape.Models.AbstractFactory.ConcreteFactories;
using ShapesInShape.Models.AbstractFactory.Products.Distributions;
using ShapesInShape.Models.BasicElements;

internal class Program
{
    private static void Main()
    {
        var factory = new CylinderInParallelepipedFactory();
        var fileWriter = new FileWriter();
        var configuration = new CaseConfiguration()
        {
            Count = 1000,
            BoundDimension = new Dimension(200, 200, 200),
            MaxLength = 25,
            MinLength = 20,
            IsSortingEnable = false,
            DistributionOfLength = new UniformDistribution(),
            DistributionOfPosition = new UniformDistribution()
        };

        var myCase = new Case(factory, configuration, fileWriter);

        myCase.Run();
    }
}

/*
 * 
 * using System;

class Program
{
    static void Main()
    {
        // Параметры первого цилиндра
        double x1 = 0;
        double y1 = 0;
        double z1 = 0;
        double radius1 = 2;
        double height1 = 5;
        double rotationX1 = 0;
        double rotationY1 = 0;
        double rotationZ1 = 0;

        // Параметры второго цилиндра
        double x2 = 0;
        double y2 = 0;
        double z2 = 10;
        double radius2 = 3;
        double height2 = 6;
        double rotationX2 = 0;
        double rotationY2 = Math.PI / 4;
        double rotationZ2 = Math.PI / 6;

        // Преобразование координат для первого цилиндра
        double transformedX1 = x1 * Math.Cos(rotationZ2) - y1 * Math.Sin(rotationZ2);
        double transformedY1 = x1 * Math.Sin(rotationZ2) + y1 * Math.Cos(rotationZ2);
        double transformedZ1 = z1;

        transformedY1 = y1 * Math.Cos(rotationX2) - transformedZ1 * Math.Sin(rotationX2);
        transformedZ1 = y1 * Math.Sin(rotationX2) + transformedZ1 * Math.Cos(rotationX2);

        transformedX1 = transformedX1 * Math.Cos(rotationY2) + transformedZ1 * Math.Sin(rotationY2);
        transformedZ1 = -transformedX1 * Math.Sin(rotationY2) + transformedZ1 * Math.Cos(rotationY2);

        transformedX1 += x2;
        transformedY1 += y2;
        transformedZ1 += z2;

        // Преобразование координат для второго цилиндра
        double transformedX2 = x2 * Math.Cos(rotationZ1) - y2 * Math.Sin(rotationZ1);
        double transformedY2 = x2 * Math.Sin(rotationZ1) + y2 * Math.Cos(rotationZ1);
        double transformedZ2 = z2;

        transformedY2 = y2 * Math.Cos(rotationX1) - transformedZ2 * Math.Sin(rotationX1);
        transformedZ2 = y2 * Math.Sin(rotationX1) + transformedZ2 * Math.Cos(rotationX1);

        transformedX2 = transformedX2 * Math.Cos(rotationY1) + transformedZ2 * Math.Sin(rotationY1);
        transformedZ2 = -transformedX2 * Math.Sin(rotationY1) + transformedZ2 * Math.Cos(rotationY1);

        transformedX2 += x1;
        transformedY2 += y1;
        transformedZ2 += z1;

        // Проверка пересечения по высоте
        double zDistance = Math.Abs(transformedZ1 - transformedZ2);
        double totalHeight = height1 / 2 + height2 / 2;

        bool heightIntersection = zDistance <= totalHeight;

        // Проверка пересечения на плоскости XY
        double xyDistance = Math.Sqrt(Math.Pow(transformedX1 - transformedX2, 2) + Math.Pow(transformedY1 - transformedY2, 2));
        double totalRadius = radius1 + radius2;

        bool xyIntersection = xyDistance <= totalRadius;

        // Проверка пересечения боковых поверхностей
        bool sideIntersection = false;
        if (heightIntersection && xyIntersection)
        {
            double dx = transformedX2 - transformedX1;
            double dy = transformedY2 - transformedY1;
            double dz = transformedZ2 - transformedZ1;

            double distanceSquared = dx * dx + dy * dy + dz * dz;

            if (distanceSquared <= totalRadius * totalRadius)
            {
                sideIntersection = true;
            }
        }

        // Вывод результата
        if (heightIntersection && (xyIntersection || sideIntersection))
        {
            Console.WriteLine("Цилиндры пересекаются.");
        }
        else
        {
            Console.WriteLine("Цилиндры не пересекаются.");
        }

        Console.ReadLine();
    }
}
*/