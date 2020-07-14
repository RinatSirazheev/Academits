using System.Collections.Generic;

namespace ShapesTask
{
    class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetArea() > y.GetArea())
            {
                return 1;
            }

            if (x.GetArea() < y.GetArea())
            {
                return -1;
            }

            return 0;
        }
    }
}