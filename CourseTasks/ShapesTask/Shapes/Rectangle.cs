namespace ShapesTask
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetHeight()
        {
            return Width;
        }

        public double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }

        public double GetWidth()
        {
            return Height;
        }

        public override string ToString()
        {
            return "Прямоугольник с длиной и высотой: " + string.Join(", ", new double[] { Width, Height });
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

            Rectangle p = (Rectangle)o;

            return Width == p.Width && Height == p.Height;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

            return hash;
        }
    }
}