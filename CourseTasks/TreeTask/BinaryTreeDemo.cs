using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TreeTask
{
    class BinaryTreeDemo
    {
        static void Main()
        {
            var tree = new BinatryTree<int>(8);
            var treeNumber = new[] { 3, 10, 1, 6, 14, 4, 7, 13 };

            for (int i = 0; i < treeNumber.Length; i++)
            {
                tree.Add(new TreeNode<int> (treeNumber[i]));
            }

            Console.WriteLine(tree.GetParentAt(13).Data);

            Console.WriteLine( tree.Contains(100));

            //tree.RemoveAt(8);

            Console.WriteLine(tree.Contains(8));

            Console.WriteLine(tree.GetParentAt(14).Data);

            tree.RemoveAt(6);

            Console.WriteLine(tree.Contains(100));
        }
    }
}