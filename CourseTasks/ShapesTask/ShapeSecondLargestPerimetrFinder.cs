using System;

namespace ShapesTask
{
    public static class ShapeSecondLargestPerimetrFinder
    {
        public static void GetShapeSecondLargestPerimetr(this IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimetrComparer());

            Console.WriteLine("{0} является фигурой со вторым по величине периметром.", shapes[shapes.Length - 2].Name);
            Console.WriteLine("Ее периметр равен {0}", shapes[shapes.Length - 2].GetPerimetr());
        }
    }
}