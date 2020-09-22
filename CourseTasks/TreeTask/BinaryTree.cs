using System;
using System.Collections.Generic;

namespace TreeTask
{
    class BinaryTree<T>
    {
        private TreeNode<T> root;

        public int Count { get; private set; }

        public IComparer<T> Comparer { get; set; }

        public BinaryTree()
        {
        }

        public BinaryTree(T data)
        {
            root = new TreeNode<T>(data);

            Count++;
        }

        public BinaryTree(T data, IComparer<T> comparer)
        {
            root = new TreeNode<T>(data);
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
            if (root == null)
            {
                return false;
            }

            var parentNode = GetParentAt(data);

            return !(parentNode == null && Compare(root, new TreeNode<T>(data)) == 1);
        }

        public void Add(T data)
        {
            Add(new TreeNode<T>(data));
        }

        private void Add(TreeNode<T> node)
        {
            if (root == null)
            {
                root = node;

            }
            else
            {
                var currentNode = root;

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
            var currentNode = root;

            while (true)
            {
                var comparisonResult = Compare(currentNode, node);

                if (comparisonResult == 0)
                {
                    result = previous;

                    break;
                }
                else if (comparisonResult > 0)
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
            if (root == null)
            {
                throw new Exception("Ошибка! Список пуст!");
            }

            var node = new TreeNode<T>(data);

            if (Compare(root, node) == 1)
            {
                if (root.Right == null && root.Left == null)
                {
                    root = null;

                    return;
                }

                if (root.Right == null)
                {
                    root = root.Left;

                    return;
                }

                if (root.Left == null)
                {
                    root = root.Right;

                    return;
                }

                var rootLeftNode = root.Left;
                root = root.Right;

                Add(rootLeftNode);

                Count--;

                return;
            }

            var parentNode = GetParentAt(data);

            if (parentNode == null)
            {
                throw new ArgumentException($"Ошибка! Элемента списка с параметром = {data} не существует", nameof(data));
            }

            var removedNode = Compare(parentNode.Left, node) == 1 ? parentNode.Left : parentNode.Right;

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

            queue.Enqueue(root);

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

        public void DepthFirstTraversing(Action<TreeNode<T>> action)
        {
            var stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();

                action(currentNode);

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

        private void Visit(TreeNode<T> node, Action<TreeNode<T>> action)
        {
            action(node);

            if (node.Left != null)
            {
                Visit(node.Left, action);
            }

            if (node.Right != null)
            {
                Visit(node.Right, action);
            }
        }

        public void Visit(Action<TreeNode<T>> action)
        {
            var node = new TreeNode<T>(root.Data);

            Visit(node, action);
        }
    }
}