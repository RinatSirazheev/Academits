using System;

namespace GraphTask
{
    class MyGraphDemo
    {
        static void Main()
        {
            var matrix = new[,]
            {
                { 0, 1, 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 1, 0, 1 },
                { 0, 0, 1, 0, 0, 1, 0 }
            };

            var graph = new MyGraph(matrix);

            Console.WriteLine("Обход несвязного графа в ширину.");

            graph.BreadthFirstTraversing(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Обход несвязного графа в глубину без использования рекурсии.");

            graph.DepthFirstTraversing(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Обход несвязного графа в глубину c использованием рекурсии.");

            graph.Visit(Console.WriteLine);
        }
    }
}