namespace ShapesTask
{
    public class ShapesDemo
    {
        static void Main()
        {
            IShape[] shapes = {
                new Square(5),
                new Square(8.8),
                new Rectangle(12, 20.5),
                new Circle(3.8),
                new Circle(8),
                new Triangle(2.4,5,10,2,8,2)
            };
                       
            shapes.GetShapeMaxArea();

            shapes.GetShapeSecondLargestPerimetr();
        }
    }
}