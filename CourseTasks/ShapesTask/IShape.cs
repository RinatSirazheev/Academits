namespace ShapesTask
{
    public interface IShape
    {
        string Name { get; }
        double GetWidth();

        double GetHeight();

        double GetArea();

        double GetPerimeter();
    }
}