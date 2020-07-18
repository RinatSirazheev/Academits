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

        public override string ToString()
        {
            return Radius.ToString();
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

            Circle p = (Circle)o;

            return Radius == p.Radius;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Radius.GetHashCode();

            return hash;
        }
    }
}