using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask
{
    class MyGraph
    {
        private bool[] visited;

        public int[,] Graph { get; private set; }

        public MyGraph(int[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {//TODO дописать исключение!
                throw new ArgumentException("");
            }

            Graph = array;
            visited = new bool[array.GetLength(0)];
        }

        public void BreadthFirstTraversing()
        {
            var queue = new Queue<int>();

            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                var curentVertex = queue.Dequeue();

                if (visited[curentVertex] == true)
                {
                    continue;
                }

                Console.WriteLine(curentVertex);

                for (int i = 1; i < Graph.GetLength(0); i++)
                {
                    if (Graph[curentVertex, i] == 1)
                    {
                        queue.Enqueue(i);

                        visited[curentVertex] = true;
                    }
                }
            }
        }
    }
}