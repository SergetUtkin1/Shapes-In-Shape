﻿using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.ConsoleApplication.Models.AbstractFactory.Products.Shapes
{
    public class Cylinder : Shape
    {
        public Cylinder(Position center, double length, double width, double heigth, double theta, double fi) : base(center, length, width, heigth, theta, fi)
        {
            Dimension = new Dimension()
            {
                Heigth = heigth,
                Length = length,
                Width = length,
                Theta = theta,
                Fi = fi,
            };
        }

        protected override double GetVolume()
        {
            double volume = Dimension.Length * double.Pi * Math.Pow(Dimension.Length, 2);
            return volume;
        }
    
    }
}
