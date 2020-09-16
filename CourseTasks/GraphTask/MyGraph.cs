using System;
using System.Collections.Generic;

namespace GraphTask
{
    class MyGraph
    {
        public int[,] Graph { get; }

        public MyGraph(int[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Ошибка! Граф должен быть неориентированный.");
            }

            Graph = array;
        }

        private void BreadthFirstTraversing(Action<int> action, int vertex, ref bool[] visited)
        {
            var queue = new Queue<int>();

            queue.Enqueue(vertex);

            while (queue.Count != 0)
            {
                var currentVertex = queue.Dequeue();

                if (visited[currentVertex] == true)
                {
                    continue;
                }

                visited[currentVertex] = true;

                action(currentVertex);

                for (var i = 1; i < Graph.GetLength(0); i++)
                {
                    if (Graph[currentVertex, i] == 1)
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }

        public void BreadthFirstTraversing(Action<int> action)
        {
            var visited = new bool[Graph.GetLength(0)];

            for (var vertexNumber = 0; vertexNumber < Graph.GetLength(0); vertexNumber++)
            {
                if (!visited[vertexNumber])
                {
                    BreadthFirstTraversing(action, vertexNumber, ref visited);
                }
            }
        }

        private void DepthFirstTraversing(Action<int> action, int vertex, ref bool[] visited)
        {
            var stack = new Stack<int>();

            stack.Push(vertex);

            while (stack.Count != 0)
            {
                var curentVertex = stack.Pop();

                if (visited[curentVertex])
                {
                    continue;
                }

                visited[curentVertex] = true;

                action(curentVertex);

                for (var i = Graph.GetLength(0) - 1; i > 0; i--)
                {
                    if (Graph[curentVertex, i] == 1)
                    {
                        stack.Push(i);
                    }
                }
            }
        }

        public void DepthFirstTraversing(Action<int> action)
        {
            var visited = new bool[Graph.GetLength(0)];

            for (var vertexNumber = 0; vertexNumber < Graph.GetLength(0); vertexNumber++)
            {
                if (!visited[vertexNumber])
                {
                    DepthFirstTraversing(action, vertexNumber, ref visited);
                }
            }
        }
    }
}