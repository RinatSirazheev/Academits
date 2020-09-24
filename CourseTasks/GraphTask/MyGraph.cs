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

        private void BreadthFirstTraversing(Action<int> action, int vertex, bool[] visited)
        {
            var queue = new Queue<int>();

            queue.Enqueue(vertex);

            while (queue.Count != 0)
            {
                var currentVertex = queue.Dequeue();

                if (visited[currentVertex])
                {
                    continue;
                }

                visited[currentVertex] = true;

                action(currentVertex);

                for (var i = 1; i < Graph.GetLength(0); i++)
                {
                    if (Graph[currentVertex, i] == 1 && !visited[i])
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
                    BreadthFirstTraversing(action, vertexNumber, visited);
                }
            }
        }

        private void DepthFirstTraversing(Action<int> action, int vertex, bool[] visited)
        {
            var stack = new Stack<int>();

            stack.Push(vertex);

            while (stack.Count != 0)
            {
                var currentVertex = stack.Pop();

                if (visited[currentVertex])
                {
                    continue;
                }

                visited[currentVertex] = true;

                action(currentVertex);

                for (var i = Graph.GetLength(0) - 1; i > 0; i--)
                {
                    if (Graph[currentVertex, i] == 1 && !visited[i])
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
                    DepthFirstTraversing(action, vertexNumber, visited);
                }
            }
        }

        private void Visit(Action<int> action, int vertex, bool[] visited)
        {
            action(vertex);

            visited[vertex] = true;

            for (var i = 0; i < Graph.GetLength(0); i++)
            {
                if (visited[i])
                {
                    continue;
                }

                if (Graph[vertex, i] == 1)
                {
                    Visit(action, i, visited);
                }
            }
        }

        public void Visit(Action<int> action)
        {
            var visited = new bool[Graph.GetLength(0)];

            for (var i = 0; i < Graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    Visit(action, i, visited);
                }
            }
        }
    }
}