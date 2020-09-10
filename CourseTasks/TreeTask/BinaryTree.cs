using System;
using System.Collections.Generic;

namespace TreeTask
{
    class BinaryTree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public IComparer<T> Comparer { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(T data)
        {
            Root = new TreeNode<T>(data);

            Count++;
        }

        public BinaryTree(T data, IComparer<T> comparer)
        {
            Root = new TreeNode<T>(data);
            Comparer = comparer;

            Count++;
        }

        private int Compare(TreeNode<T> currentNode, TreeNode<T> node)
        {
            if (Comparer != null)
            {
                return Comparer.Compare(currentNode.Data, node.Data);
            }

            IComparable<T> p = (IComparable<T>)currentNode.Data;
            return p.CompareTo(node.Data);
        }

        public bool Contains(T data)
        {
            if (Root == null)
            {
                return false;
            }

            var parentNode = GetParentAt(data);

            return !(parentNode == null && Compare(Root, new TreeNode<T>(data)) == 1);
        }

        public void Add(T data)
        {
            Add(new TreeNode<T>(data));
        }

        private void Add(TreeNode<T> node)
        {
            if (Root == null)
            {
                Root = node;

            }
            else
            {
                var currentNode = Root;

                while (true)
                {
                    if (Compare(currentNode, node) > 0)
                    {
                        if (currentNode.Left != null)
                        {
                            currentNode = currentNode.Left;

                            continue;
                        }
                        else
                        {
                            currentNode.Left = node;
                            Count++;

                            break;
                        }
                    }
                    else
                    {
                        if (currentNode.Right != null)
                        {
                            currentNode = currentNode.Right;

                            continue;
                        }
                        else
                        {
                            currentNode.Right = node;
                            Count++;

                            break;
                        }
                    }
                }
            }
        }

        private TreeNode<T> GetParentAt(T data)
        {
            TreeNode<T> result = default;
            TreeNode<T> previous = default;
            TreeNode<T> node = new TreeNode<T>(data);
            var currentNode = Root;

            while (true)
            {
                var comparsionResult = Compare(currentNode, node);

                if (comparsionResult == 0)
                {
                    result = previous;

                    break;
                }
                else if (comparsionResult > 0)
                {
                    if (currentNode.Left != null)
                    {
                        previous = currentNode;
                        currentNode = currentNode.Left;

                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        previous = currentNode;
                        currentNode = currentNode.Right;

                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public void RemoveAt(T data)
        {
            if (Root == null)
            {
                throw new Exception("Ошибка! Список пуст!");
            }

            if (Compare(Root, new TreeNode<T>(data)) == 1)
            {
                if (Root.Right == null && Root.Left == null)
                {
                    Root = null;

                    return;
                }

                if (Root.Right == null)
                {
                    Root = Root.Left;

                    return;
                }

                if (Root.Left == null)
                {
                    Root = Root.Right;

                    return;
                }

                var rootLeftNode = Root.Left;
                Root = Root.Right;

                Add(rootLeftNode);

                Count--;

                return;
            }

            var parentNode = GetParentAt(data);

            if (parentNode == null)
            {
                throw new ArgumentException($"Ошибка! Элемента списка с параметром = {data} не существует", nameof(data));
            }

            var removedNode = Equals(parentNode.Left.Data, data) ? parentNode.Left : parentNode.Right;

            if (removedNode.Left == null && removedNode.Right == null)
            {
                if (Compare(removedNode, parentNode) >= 0)
                {
                    parentNode.Right = null;
                    Count--;
                }
                else
                {
                    parentNode.Left = null;
                    Count--;
                }
            }
            else if (removedNode.Left == null || removedNode.Right == null)
            {
                var child = removedNode.Right ?? removedNode.Left;

                if (Compare(removedNode, parentNode) >= 0)
                {
                    parentNode.Left = child;
                    Count--;
                }
                else
                {
                    parentNode.Right = child;
                    Count--;
                }
            }
            else
            {
                var minLeftNode = removedNode.Right;
                var minLeftNodeParent = removedNode;

                while (minLeftNode.Left != null)
                {
                    minLeftNodeParent = minLeftNode;
                    minLeftNode = minLeftNode.Left;
                }

                if (minLeftNode.Right != null)
                {
                    minLeftNodeParent.Left = minLeftNode.Right;
                }
                else
                {
                    minLeftNodeParent.Left = null;
                }

                if (Compare(parentNode, removedNode) < 0)
                {
                    parentNode.Right = minLeftNode;
                }
                else
                {
                    parentNode.Left = minLeftNode;
                }

                minLeftNode.Left = removedNode.Left;
                minLeftNode.Right = removedNode.Right;
                Count--;
            }
        }

        public void BreadthFirstTraversing(Action<TreeNode<T>> action)
        {
            var queue = new Queue<TreeNode<T>>();

            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                action(currentNode);

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public void DepthFirstTraversing()
        {
            var stack = new Stack<TreeNode<T>>();

            stack.Push(Root);

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();

                Console.WriteLine(currentNode);

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        public void Visit(TreeNode<T> node)
        {
            Console.WriteLine(node);

            if (node.Left != null)
            {
                Visit(node.Left);
            }

            if (node.Right != null)
            {
                Visit(node.Right);
            }
        }
    }
}