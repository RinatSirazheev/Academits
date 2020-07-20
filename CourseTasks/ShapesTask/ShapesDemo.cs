using System;

namespace ShapesTask
{
    public class ShapesDemo
    {
        static void Main()
        {
            IShape[] shapes = {
                new Square(5),
                new Square(8.8),
                new Rectangle(12, 20.5),
                new Circle(3.8),
                new Circle(8),
                new Triangle(2.4,5,10,2,8,2)
            };

            Array.Sort(shapes, new ShapesAreaComparer());

            Console.WriteLine("{0} является фигурой с самой большой площадью.", shapes[shapes.Length - 1].Name);
            Console.WriteLine("Ее площадь равна {0}", shapes[shapes.Length - 1].GetArea());

            Array.Sort(shapes, new ShapesPerimeterComparer());

            Console.WriteLine("{0} является фигурой со вторым по величине периметром.", shapes[shapes.Length - 2].Name);
            Console.WriteLine("Ее периметр равен {0}", shapes[shapes.Length - 2].GetPerimeter());
        }
    }
}