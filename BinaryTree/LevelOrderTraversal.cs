namespace FAANGInterviewQuestions.BinaryTree
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-level-order-traversal/
    /// </summary>
    public static class LevelOrderTraversal
    {
        public static void Execute()
        {
            var a = new LevelOrderTraversalTreeNode(3);

            var b = new LevelOrderTraversalTreeNode(9);
            var c = new LevelOrderTraversalTreeNode(20);

            a.left = b;
            a.right = c;

            var d = new LevelOrderTraversalTreeNode(15);
            var e = new LevelOrderTraversalTreeNode(7);

            c.left = d;
            c.right = e;

            //Output: [[3],[9,20],[15,7]]

            var levels = LevelOrder(a);
            var result = "[" + string.Join(",", levels.Select(l => "[" + string.Join(",", l) + "]")) + "]";
            Console.WriteLine(result);
            //Console.WriteLine(string.Join(",", BFS(a)));

        }
        
        //Breath First Search Algorithme
        public static List<int> BFS(LevelOrderTraversalTreeNode root)
        {
            var result = new List<int>();
            var queue = new Queue<LevelOrderTraversalTreeNode>();
            queue.Enqueue(root);
            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            return result;
        }

        //T: O(N) -> because one node is touched only one time
        //S: O(N) -> because results is O(N) and queue is 0(N/2) <=> O(2N) <=> O(N)
        public static IList<IList<int>> LevelOrder(LevelOrderTraversalTreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;

            var queue = new Queue<LevelOrderTraversalTreeNode>();
            queue.Enqueue(root);
            while (queue.Count() > 0)
            {
                var length = queue.Count();
                var count = 0;
                var currentLevelVales = new List<int>();
                while(count < length)
                {
                    count++;
                    var node = queue.Dequeue();
                    currentLevelVales.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

               result.Add(currentLevelVales);

            }

            return result;
        }

    }

    public class LevelOrderTraversalTreeNode
    {
        public int val;
        public LevelOrderTraversalTreeNode left;
        public LevelOrderTraversalTreeNode right;
        public LevelOrderTraversalTreeNode(int val = 0,
                                           LevelOrderTraversalTreeNode left = null,
                                           LevelOrderTraversalTreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
