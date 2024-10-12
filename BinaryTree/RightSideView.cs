namespace FAANGInterviewQuestions.BinaryTree
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-right-side-view/description/
    /// </summary>
    public static class BTRightSideView
    {
        public static void Execute()
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);

            //n1.left = n2;
            n1.right = n3;
            //n3.right = n4;
            //n3.right = n4;

            var result = RightSideViewWithDFS(n1);

            Console.WriteLine(string.Join(",", RightSideViewWithDFS(n1)));
        }

        public static IList<int> RightSideViewWithBFS(TreeNode root)
        {
            IList<int> result = new List<int>();

            if (root == null) return result;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var lenght = queue.Count();
                var count = 0;
                while(count < lenght)
                {
                    var node = queue.Dequeue();
                    if (count == lenght - 1) result.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    count++;
                }
            }

            return result;
        }

        public static IList<int> RightSideViewWithDFS(TreeNode root)
        {
            IList<int> result = new List<int>();
            DFS(root, 0, result);
            return result;
        }

        private static void DFS(TreeNode node, int currentLevel, IList<int> result)
        {
            if (node == null) return;

            if (currentLevel == result.Count)
            {
                result.Add(node.val);
            }
            if(node.right != null)
            {
                DFS(node.right, currentLevel + 1, result);
            }
            if (node.left != null)
            {
                DFS(node.left, currentLevel + 1, result);
            }
        }
    }
}
