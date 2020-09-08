using System;
using System.Collections.Generic;

namespace GraphTask1
{
    class MyGraph
    {
        public int[,] Graph { get; private set; }

        public MyGraph(int[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Ошибка! Граф должен быть неориентированный.");
            }

            Graph = array;
        }

        public void BreadthFirstTraversing()
        {
            var queue = new Queue<int>();
            var visited = new bool[Graph.GetLength(0)];

            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                var curentVertex = queue.Dequeue();

                if (visited[curentVertex] == true)
                {
                    continue;
                }

                visited[curentVertex] = true;

                Console.WriteLine(curentVertex);

                for (int i = 1; i < Graph.GetLength(0); i++)
                {
                    if (Graph[curentVertex, i] == 1)
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }

        public void DepthFirstTraversing()
        {
            var stack = new Stack<int>();
            var visited = new bool[Graph.GetLength(0)];

            stack.Push(0);

            while (stack.Count != 0)
            {
                var curentVertex = stack.Pop();

                if (visited[curentVertex] == true)
                {
                    continue;
                }

                visited[curentVertex] = true;

                Console.WriteLine(curentVertex);

                for (int i = Graph.GetLength(0) - 1; i > 0; i--)
                {
                    if (Graph[curentVertex, i] == 1)
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
}