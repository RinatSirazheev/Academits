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



    }
}