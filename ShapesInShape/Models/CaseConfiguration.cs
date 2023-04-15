using ShapesInShape.Models.AbstractFactory.Products.AbstractProducts;
using ShapesInShape.Models.BasicElements;

namespace ShapesInShape.Models
{
    public class CaseConfiguration
    {
        public int Count { get; set; }
        public double MaxLength { get; set; }
        public double MinLength { get; set; }
        public Dimension BoundDimension { get; set; } = null!;
        public Distribution DistributionOfPosition { get; set; } = null!;
        public Distribution DistributionOfLength { get; set; } = null!;
    }
}
