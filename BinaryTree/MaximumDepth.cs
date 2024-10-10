namespace FAANGInterviewQuestions.BinaryTree
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// </summary>
    public static class MaximumDepth
    {
        public static void Execute()
        {

        }

        public static int MaxDepth(TreeNode root)
        {
            var current = root;
            var maxDepth = 0;
            while (current != null)
            {
                if (current.left != null || current.right != null)
                {
                    maxDepth++;
                }
                MaxDepth(current.left);
                MaxDepth(current.right);
            }
            
          
            return maxDepth;
        }


        //Depth First Search Algorithme
        public static int GetMaxDepth(TreeNode node, int currentDepth)
        {
            if(node == null) return currentDepth;
            currentDepth++;
            return Math.Max(GetMaxDepth(node.left, currentDepth), GetMaxDepth(node.right, currentDepth));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
