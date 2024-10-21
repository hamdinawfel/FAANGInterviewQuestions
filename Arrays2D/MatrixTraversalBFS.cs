using System.Security;

namespace FAANGInterviewQuestions.Arrays2D
{
    public static class MatrixTraversalBFS
    {
        public static void Execute()
        {
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var result = TraversalDFS(matrix);
            Console.WriteLine(string.Join(",", result));
        }
        public static List<int> TraversalDFS(int[,] matrix)
        {
            var values = new List<int>();
            var directions = new List<int[]>
            {
                new int[] { 0, 1 }, // UP
                new int[] { 1, 0 }, // RIGHT
                new int[] { 0, -1 }, // LEFT
                new int[] { -1, 0 }  // DOWN
            };
            var queue = new Queue<int[]>();
            queue.Enqueue([0, 0]);

            bool[,] seens = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            while (queue.Count > 0)
            {
                var currentPosition = queue.Dequeue();
                var row = currentPosition[0];
                var column = currentPosition[1];

                if(row < 0|| row >= matrix.GetLength(0) || column < 0 || column >= matrix.GetLength(1) || seens[row, column])
                {
                    continue;
                }

                seens[row, column] = true;
                values.Add(matrix[row, column]);

                for(int i = 0; i < directions.Count; i++)
                {
                    var currentDir = directions[i];
                    queue.Enqueue([row + currentDir[0], column + currentDir[1]]);
                }
            }
            return values;
        }
    }
}
