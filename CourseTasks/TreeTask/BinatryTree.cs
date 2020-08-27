using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTask
{
    class BinatryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        public BinatryTree(T data)
        {
            Root = new TreeNode<T>(data);
        }

        public bool Contains(T data)
        {
            bool result = false;

            while (Root != null)
            {
                if (Root.Data.CompareTo(data) == 0)
                {
                    result = true;

                    break;
                }
                else if (Root.Data.CompareTo(data) > 0)
                {
                    if (Root.Left != null)
                    {
                        Root = Root.Left;

                        continue;
                    }
                    else
                    {
                        result = false;

                        break;
                    }
                }
                else
                {
                    if (Root.Right != null)
                    {
                        Root = Root.Right;

                        continue;
                    }
                    else
                    {
                        result = false;

                        break;
                    }
                }
            }

            return result;
        }

        public void Add(T data)
        {
            while (true)
            {
                if (Root.Data.CompareTo(data) > 0)
                {
                    if (Root.Left != null)
                    {
                        Root = Root.Left;

                        continue;
                    }
                    else
                    {
                        Root.Left = new TreeNode<T>(data);

                        break;
                    }
                }
                else
                {
                    if (Root.Right != null)
                    {
                        Root = Root.Right;

                        continue;
                    }
                    else
                    {
                        Root.Right = new TreeNode<T>(data);

                        break;
                    }
                }
            }

        }
    }
}