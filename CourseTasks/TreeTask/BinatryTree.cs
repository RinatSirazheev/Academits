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

        public TreeNode<T> GetNode(T data)
        {
            TreeNode<T> result = default;

            while (true)
            {
                if (Root.Data.CompareTo(data) == 0)
                {
                    result = Root;

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

        public void Remove(T data)
        {

        }


    }
}