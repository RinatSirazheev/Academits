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

        public double GetPerimetr()
        {
            return SideLengthA * 2 + SideLengthB * 2;
        }

        public double GetWidth()
        {
            return SideLengthB;
        }
    }
}