using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTask
{
    class BinaryTreeDemo
    {
        static void Main()
        {
            var tree = new BinatryTree<int>(10);

            tree.Add(11);
            tree.Add(8);
            tree.Add(9);

            Console.WriteLine(tree.GetNode(8).Right.Data);
        }
    }
}
