using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.Models.BasicElements
{
    internal class Dimension
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Dimension(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            Heigth = heigth;
        }

        public Dimension(double length)
        {
            Length = length;
            Width = length;
            Heigth = length;
        }
    }
}
