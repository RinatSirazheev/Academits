using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTask
{
    class BinatryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public BinatryTree(T data)
        {
            Root = new TreeNode<T>(data);
        }

        public bool Contains(T data)
        {
            var parentNode = GetParentAt(data);

            if (parentNode == null && !Equals(Root.Data, data))
            {
                return false;
            }

            return true;
        }

        public void Add(TreeNode<T> node)
        {
            var currentNode = Root;

            while (true)
            {
                if (currentNode.Data.CompareTo(node.Data) > 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;

                        continue;
                    }
                    else
                    {
                        currentNode.Left = node;

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

                        break;
                    }
                }
            }

        }

        public TreeNode<T> GetParentAt(T data)
        {
            TreeNode<T> result = default;
            TreeNode<T> previous = default;
            var currentNode = Root;

            while (true)
            {
                if (currentNode.Data.CompareTo(data) == 0)
                {
                    result = previous;

                    break;
                }
                else if (currentNode.Data.CompareTo(data) > 0)
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
            if (Equals(Root.Data, data))
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

                return;
            }

            var parentNode = GetParentAt(data);

            if (parentNode == null)
            {
                throw new ArgumentException($"Ошибка! Элемента списка с параметром = {data} не существует", nameof(data));
            }
                       
            var removedNode = Equals(parentNode.Left, data) ? parentNode.Left : parentNode.Right;

            if (removedNode.Left == null && removedNode.Right == null)
            {

            }


        }
    }
}