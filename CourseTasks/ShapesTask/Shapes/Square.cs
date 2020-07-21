using System;

namespace ShapesTask
{
    public class Square : IShape
    {
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
            return "Квадрат со стороной = " + SideLength.ToString();
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
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