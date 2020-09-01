namespace TreeTask
{
    class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }
        
        public T Data { get; set; }

        public TreeNode()
        {

        }

        public TreeNode(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}