using System;

namespace TreeTask
{
    class BinaryTreeDemo
    {
        static void Main()
        {
            var tree = new BinaryTree<string>();
            var treeNumber = new[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };

            for (int i = 0; i < treeNumber.Length; i++)
            {
                tree.Add(treeNumber[i] + " test");
            }
            tree.Add(null);
            Console.WriteLine(tree.Contains(8 + " test"));

            tree.RemoveAt("7 test");

            Console.WriteLine(tree.Contains("4 test"));

            Console.WriteLine(tree.Count);
            tree.BreadthFirstTraversing(Console.WriteLine);

            Console.WriteLine();

            tree.Visit(tree.Root);

            Console.WriteLine();

            tree.DepthFirstTraversing();


        }
    }
}