using System.Collections.Generic;

namespace ShapesTask
{
    class ShapesPerimetrComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetPerimetr() > y.GetPerimetr())
            {
                return 1;
            }

            if (x.GetPerimetr() < y.GetPerimetr())
            {
                return -1;
            }

            return 0;
        }
    }
}