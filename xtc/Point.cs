using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xtc
{
    public class Point
    {
        public double x;
        public double y;
        public bool right = false;

        public Point(double _x, double _y, bool _right)
        {
            x = _x;
            y = _y;
            right = _right;
        }

    }
}
