namespace ShapesInShape.Models.BasicElements
{
    public class Edge
    {
        public Position Start { get; set; }
        public Position End { get; set; }

        public Edge(Position start, Position end)
        {
            Start = start;
            End = end;
        }
    }
}
