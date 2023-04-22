namespace ShapesInShape.Models.BasicElements
{
    public class Dimension
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Dimension()
        {

        }

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
