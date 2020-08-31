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

            if (parentNode == null && !Equals(Root.Data,data))
            {
                return false;
            }

            return true;
        }

        public void Add(T data)
        {
            var currentNode = Root;

            while (true)
            {
                if (currentNode.Data.CompareTo(data) > 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;

                        continue;
                    }
                    else
                    {
                        currentNode.Left = new TreeNode<T>(data);

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
                        currentNode.Right = new TreeNode<T>(data);

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
            if (!Contains(data))
            {
                throw new ArgumentException($"Ошибка! Элемента списка с параметром = {data} не существует", nameof(data));
            }


        }
    }
}