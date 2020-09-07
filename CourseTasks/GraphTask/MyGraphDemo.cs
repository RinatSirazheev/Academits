using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };

            var graph = new MyGraph(matrix);

            graph.BreadthFirstTraversing();
        }
    }
}