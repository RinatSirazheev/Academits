using System.Collections.Generic;

namespace ShapesTask
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x.GetPerimeter() > y.GetPerimeter())
            {
                return 1;
            }

            if (x.GetPerimeter() < y.GetPerimeter())
            {
                return -1;
            }

            return 0;
        }
    }
}