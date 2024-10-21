using System.Data.Common;
using System.Net;

namespace FAANGInterviewQuestions.Arrays2D
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-islands/description/
    /// </summary>
    public static class NumberOfIslands
    {
        public static void Execute()
        {
            char[][] grid =
            {
               [ '1', '0', '1', '1', '0' ],
               [ '0', '0', '0', '1', '0' ],
               [ '0', '0', '0', '0', '0' ],
               [ '0', '0', '0', '0', '0' ]
            };
            char[][] grid2 = 
            { 
                ['1', '1', '0', '0', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '1', '0', '0'], 
                ['0', '0', '0', '1', '1']
            };

            Console.WriteLine(NumIslands(grid));

        }
        public static int NumIslands(char[][] grid)
        {
            var numIslands = 0;
            var directions = new List<int[]>
            {
                new int[] { -1, 0 }, // UP
                new int[] { 0, 1 }, // RIGHT
                new int[] { 1, 0 }, // DOWN
                new int[] { 0, -1 }  // LEFT
            };
            var queue = new Queue<int[]>();
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIslands++;
                        queue.Enqueue([ i, j ]);
                        grid[i][j] = '0';
                        while(queue.Count > 0)
                        {
                            var currentLand = queue.Dequeue();
                            for (int d = 0; d < directions.Count; d++)
                            {
                                var row = currentLand[0] + directions[d][0];
                                var col = currentLand[1] + directions[d][1];
                                if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
                                {
                                    continue;
                                }
                                if (grid[row][col] == '1')
                                {
                                    queue.Enqueue([ row, col ]);
                                    grid[row][col] = '0';
                                }
                            }
                        }
                       
                    }
                }
            }
            return numIslands;
        }
    }
}
