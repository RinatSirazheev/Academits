using System;
using System.Collections.Generic;

namespace TreeTask
{
    class TreeComparer : IComparer<double>
    {
        public int Compare(double node1, double node2)
        {
            return node1.CompareTo(node2);
        }
    }
}
