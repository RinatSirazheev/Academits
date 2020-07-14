using System;

namespace ShapesTask
{
    public static class ShapeMaxAreaFinder
    {
        public static void GetShapeMaxArea(this IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());

            Console.WriteLine("{0} является фигурой с самой большой площадью.", shapes[shapes.Length - 1].Name);
            Console.WriteLine("Ее площадь равна {0}", shapes[shapes.Length - 1].GetArea());
        }
    }
}