using System;
using System.Collections;
using System.Collections.Generic;

namespace ShapesTask
{
   public interface IShape
    {
        string Name { get; }
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimetr();
    }

    public class Square : IShape
    {
        public string Name { get; }

        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
            Name = "Квадрат";
        }

        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimetr()
        {
            return 4 * SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }
    }

    public class Triangle : IShape
    {
        public string Name { get; }

        public double X1 { get; set; }

        public double X2 { get; set; }

        public double X3 { get; set; }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            Name = "Треугольник";
            X1 = x1;
            X2 = x2;
            X3 = x3;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
        }

        public double GetArea()
        {
            return Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1)) / 2;
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetPerimetr()
        {
            double segmentAB = Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
            double segmentAC = Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
            double segmentBC = Math.Sqrt(Math.Pow((X3 - X2), 2) + Math.Pow((Y3 - Y2), 2));

            return segmentAB + segmentAC + segmentBC;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }
    }

    public class Rectangle : IShape
    {
        public string Name { get; }

        public double SideLengthA { get; set; }

        public double SideLengthB { get; set; }

        public Rectangle(double sideLengthA, double sideLengthB)
        {
            Name = "Прямоугольник";
            SideLengthA = sideLengthA;
            SideLengthB = sideLengthB;
        }

        public double GetArea()
        {
            return SideLengthA * SideLengthB;
        }

        public double GetHeight()
        {
            return SideLengthA;
        }

        public double GetPerimetr()
        {
            return SideLengthA * 2 + SideLengthB * 2;
        }

        public double GetWidth()
        {
            return SideLengthB;
        }
    }

    public class Circle : IShape
    {
        public string Name { get; }

        public double Radius { get; set; }

        public Circle(double radius)
        {
            Name = "Круг";
            Radius = radius;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimetr()
        {
            return 2 * Math.PI * Radius;
        }
    }

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

    public static class ShapeMaxAreaFinder
    {
        public static void GetShapeMaxArea(this IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());

            Console.WriteLine("{0} является фигурой с самой большой площадью.", shapes[shapes.Length - 1].Name);
            Console.WriteLine("Ее площадь равна {0}", shapes[shapes.Length - 1].GetArea());
        }
    }

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