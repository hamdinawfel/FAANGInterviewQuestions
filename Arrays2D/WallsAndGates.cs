using System.Collections.Generic;
using System.Data.Common;

namespace FAANGInterviewQuestions.Arrays2D
{
    public static class WallsAndGates
    {
        const int INF = int.MaxValue;
        const int WALL = -1;
        const int GATE = -1;

        static List<int[]> directions = new List<int[]>
        {
            new int[] { -1, 0 },  // Up
            new int[] { 0, 1 },   // Right
            new int[] { 1, 0 },   // Down
            new int[] { 0, -1 }   // Left
        };
        public static void Execute()
        {
            int[][] grid =
            {
                [INF, -1, 0, INF],
                [INF, INF, INF, -1],
                [INF, -1, INF, -1],
                [0, -1, INF, INF],
            };
            

            int[][] expected =
            {
                [3, -1, 0, 1],
                [2, 2, 1, -1],
                [1, -1, 2, -1],
                [0, -1, 3, 4],
            };

            foreach (var row in expected)
            {
                Console.WriteLine($"[{string.Join(",", row)} ]");
            }

            var results = GetResult(grid);
            Console.WriteLine("---------------------------");
            foreach (var row in results)
            {
                Console.WriteLine($"[{string.Join(",", row)} ]");
            }


        }
        public static int[][] GetResult(int[][] grid)
        {
            for (int i = 0; i <grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        DFS(grid, i, j, 0);
                    }
                }
            }
            return grid;
        }

        private static void DFS(int[][] grid, int row, int col, int step)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] < step)
            {
                return;
            }

            grid[row][col] = step;

            for (int d = 0 ; d < directions.Count; ++d)
            {
                var currentDir = directions[d];
                DFS(grid, row + currentDir[0], col + currentDir[1], step + 1);
            }
        }
    }
}
