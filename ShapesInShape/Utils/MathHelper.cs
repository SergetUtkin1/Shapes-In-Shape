using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInShape.ConsoleApplication.Utils
{
    static class MathHelper
    {
        public static double[] GetLinSpace(double startval, double endval, int steps)
        {
            double interval = (endval / MathF.Abs((float)endval)) * MathF.Abs((float)endval - (float)startval) / (steps - 1);
            return (from val in Enumerable.Range(0, steps)
                    select startval + (val * interval)).ToArray();
        }
    }
}
