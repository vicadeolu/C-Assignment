using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoA
{
    public class ShapeDetector
    {
        public string GetImageOrientation(int width, int height)
        {
            if (width > height)
                return "Landscape";
            else if (width < height)
                return "Portrait";
            else
                return "Square";
        }
    }
}
