using System.Reflection.Emit;

namespace FAANGInterviewQuestions.Arrays2D
{
    /// <summary>
    /// https://leetcode.com/problems/rotting-oranges/
    /// </summary>
    public static class RottingOrangesSol
    {
        public static void Execute()
        {
            int[][] grid =
            {
                [2, 1, 1],
                [1, 1, 0],
                [0, 1, 1],
            };
            int[][] grid1 = {[2, 0, 1, 1, 1, 1, 1, 1, 1, 1], [1, 0, 1, 0, 0, 0, 0, 0, 0, 1], [1, 0, 1, 0, 1, 1, 1, 1, 0, 1], [1, 0, 1, 0, 1, 0, 0, 1, 0, 1], [1, 0, 1, 0, 1, 0, 0, 1, 0, 1], [1, 0, 1, 0, 1, 1, 0, 1, 0, 1], [1, 0, 1, 0, 0, 0, 0, 1, 0, 1], [1, 0, 1, 1, 1, 1, 1, 1, 0, 1], [1, 0, 0, 0, 0, 0, 0, 0, 0, 1], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]};
            int[][] grid2 = { [1, 2]};
            Console.WriteLine(OrangesRotting(grid));
        }
        public static int OrangesRotting(int[][] grid)
        {
            var times = 0;
            var directions = new List<int[]>
            {
                new int[] { -1, 0 }, //U
                new int[] { 0, 1 }, //R
                new int[] { 1, 0 }, //D
                new int[] { 0, -1 }, //L
            };
            var queue = new Queue<int[]>();

            var freshCount = 0;
            for ( int i = 0; i< grid.Length; i++ )
            {
                for ( int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue([i, j]);
                    }
                    if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }
            if (freshCount == 0) return 0;
            var queueSize = queue.Count;

            while (queue.Count > 0)
            {
                if (queueSize == 0)
                {
                    times++;
                    queueSize = queue.Count;
                }
                var currentRotted = queue.Dequeue();
                queueSize--;
                for (var d = 0; d < directions.Count; d++)
                {
                    var row = currentRotted[0] + directions[d][0];
                    var col = currentRotted[1] + directions[d][1];

                    if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
                    {
                        continue;
                    }
                    if (grid[row][col] == 1)
                    {
                        grid[row][col] = 2;
                        freshCount--;
                        queue.Enqueue([row, col]);

                       
                    }
                }
            }
            return freshCount > 0? -1 : times;
        }
        ///TODO : implement correction : https://replit.com/@ZhangMYihua/Rotting-Oranges-Solution#main.js
    }
}
