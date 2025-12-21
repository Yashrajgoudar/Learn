namespace CodingI.SolveQuestions._2_D_Arrays
{
    internal class Q1DiagonalTraversalOfMatrix
    {
        // This code performs a diagonal traversal of a given 2D matrix.
        public static void DiagonalTraversal(int[][] mat)
        {
            int n = mat.Length;
            int m = mat[0].Length;

            // There will be n+m-1 diagonals in total
            for (int line = 1; line <= (n + m - 1); line++)
            {

                // Get column index of the first element in 
                // this diagonal. The index is 0 for first 'n' 
                // lines and (line - n) for remaining lines
                int startCol = Math.Max(0, line - n);

                // Get count of elements in this diagonal
                // Count equals minimum of line number, (m-startCol) and n
                int count = Math.Min(Math.Min(line, m - startCol), n);

                // Process elements of this diagonal
                for (int j = 0; j < count; j++)
                {

                    // Calculate row and column indices 
                    // for each element in the diagonal
                    int row = Math.Min(n, line) - j - 1;
                    int col = startCol + j;
                    Console.Write(mat[row][col] + " ");
                }
            }
        }
        public static void main(string[] args)
        {
            int[][] mat =  [[1, 2, 3, 4 ],
                            [5, 6, 7, 8 ],
                            [9, 10, 11, 12],
                            [13, 14, 15, 16],
                            [17, 18, 19, 20]];
            DiagonalTraversal(mat);
        }
    }
}
