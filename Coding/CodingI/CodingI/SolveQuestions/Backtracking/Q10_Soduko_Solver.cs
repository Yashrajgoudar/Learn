namespace CodingI.SolveQuestions.Backtracking
{
    public class Q10_Soduko_Solver
    {
        public static bool IsSafe(int[,] mat, int row, int col, int val)
        {
            //horizontal check
            for (int j = 0; j < 9; j++)
            {
                if (mat[row, j] == val)
                {
                    return false;
                }                
            }

            //vertical check
            for(int i = 0;i < 9; i++)
            {
                if (mat[i, col] == val)
                {
                    return false;
                }
            }


            //grid check
            int srow = (row / 3) * 3;
            int scol = (col / 3) * 3;

            for(int i = srow; i <= srow + 2; i++)
            {
                for(int j = scol; j <= scol + 2; j++)
                {
                    if(mat[i, j] == val)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static bool SolveSudoko(int[,] mat, int row, int col)
        {
            if (row == 9)
            {
                return true;
            }
            int nextRow = row, nextCol = col+1;
            if(nextCol == 9)
            {
                nextCol = 0;
                nextRow = nextRow+1;
            }
            if (mat[row,col] != 0)
            {
                return SolveSudoko(mat,nextRow,nextCol);
            }
            for(int i = 1; i <= 9; i++)
            {
                if (IsSafe(mat,row,col,i))
                {
                    mat[row, col] = i;
                    if(SolveSudoko(mat, nextRow, nextCol))
                    {
                        return true;
                    }
                    mat[row, col] = 0;
                }
            }
            return false;
        }
        public static void main()
        {
            int[,] mat = {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            SolveSudoko(mat, 0, 0);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
