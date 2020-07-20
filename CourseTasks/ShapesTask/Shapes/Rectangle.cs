namespace ShapesTask
{
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

        public double GetPerimeter()
        {
            return SideLengthA * 2 + SideLengthB * 2;
        }

        public double GetWidth()
        {
            return SideLengthB;
        }

        public override string ToString()
        {
            return string.Join(", ", new double[] { SideLengthA, SideLengthB });
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

            Rectangle p = (Rectangle)o;

            return SideLengthA == p.SideLengthA && SideLengthB == p.SideLengthB;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + SideLengthA.GetHashCode();
            hash = prime * hash + SideLengthB.GetHashCode();

            return hash;
        }
    }
}