namespace FAANGInterviewQuestions.Arrays2D
{
    public static class MatrixTraversalDFS
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
            bool[,] seens = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            DFS(matrix, directions, 0, 0, seens, values);
            return values;
        }

        private static void DFS(int[,] matrix, List<int[]> directions, int row, int column, bool[,] seens, List<int> values)
        {
            if(row < 0 || column < 0 || row >= matrix.GetLength(0) || column >= matrix.GetLength(1) || seens[row, column]) 
            {
                return;
            }
            values.Add(matrix[row, column]);
            seens[row, column] = true;
            for(int i = 0; i < directions.Count; i++)
            {
                var currentDir = directions[i];
                DFS(matrix, directions, row + currentDir[0], column + currentDir[1], seens, values);
            }
        }
    }
}
