using System;

namespace TreeTask
{
    class BinaryTreeDemo
    {
        static void Main()
        {
            var tree = new BinaryTree<double>(8);
            var treeNumber = new[] { 3, 10, 1, 6, 4, 7, 14, 13 };

            for (int i = 0; i < treeNumber.Length; i++)
            {
                tree.Add(treeNumber[i]);
            }

            Console.WriteLine(tree.Contains(100));

            tree.RemoveAt(8);

            Console.WriteLine(tree.Contains(8));

            Console.WriteLine(tree.Count);
            tree.BreadthFirstTraversing();

            Console.WriteLine();

            tree.Visit(tree.Root);

            Console.WriteLine();

            tree.DepthFirstTraversing();
        }
    }
}