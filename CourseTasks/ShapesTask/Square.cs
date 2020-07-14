using System;

namespace ShapesTask
{
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
}