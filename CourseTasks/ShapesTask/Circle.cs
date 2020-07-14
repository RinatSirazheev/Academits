using System;

namespace ShapesTask
{
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
}