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

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public override string ToString()
        {
            return SideLength.ToString();
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (o is null || o.GetType() != this.GetType())
            {
                return false;
            }

            Square p = (Square)o;

            return SideLength == p.SideLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + SideLength.GetHashCode();

            return hash;
        }
    }
}