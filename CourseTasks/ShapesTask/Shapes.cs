using System;

namespace ShapesTask
{
    class Shapes
    {
        interface IShape
        {
            double GetWidth();
            double GetHeight();
            double GetArea();
            double GetPerimetr();
        }

        public class Square : IShape
        {
            private double sideLength;

            public double SideLength { get; set; }

            public Square(double sideLength)
            {
                SideLength = sideLength;
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
            private double x1;
            private double x2;
            private double x3;
            private double y1;
            private double y2;
            private double y3;

            public double X1 { get; set; }

            public double X2 { get; set; }

            public double X3 { get; set; }

            public double Y1 { get; set; }

            public double Y2 { get; set; }

            public double Y3 { get; set; }

            public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
            {
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
                throw new NotImplementedException();
            }

            public double GetPerimetr()
            {
                throw new NotImplementedException();
            }

            public double GetWidth()
            {
                throw new NotImplementedException();
            }
        }
    }
}
