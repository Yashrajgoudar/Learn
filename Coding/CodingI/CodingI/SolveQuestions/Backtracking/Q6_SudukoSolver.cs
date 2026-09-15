using CodingI.RequiredProblems.Recursion;

namespace CodingI.SolveQuestions.Backtracking
{
    public class Q6_SudukoSolver
    {
        public static bool isSafe(char[][] board, int row, int col, int dig)
        {
            int start_row = row / 3 * 3;
            int start_col = col / 3 * 3;

            //Horizontal Check
            for (int j = 0; j < 9; j++)
            {
                if (board[row][j] == dig)
                {
                    return false;
                }
            }

            //Vertical Check
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == dig)
                {
                    return false;
                }
            }

            //Box Check
            for (int i = start_row; i <= start_row + 2; i++)
            {
                for (int j = start_col; j <= start_col + 2; j++)
                {
                    if (board[i][j] == dig)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool SolveSudoku(char[][] board, int row, int col)
        {
            if (row == 9)
            {
                return true;
            }

            int nextRow = row, nextCol = col + 1;
            if (nextCol == 9)
            {
                nextRow = row + 1;
                nextCol = 0;
            }

            if (board[row][col] != '.')
            {
                return SolveSudoku(board, nextRow, nextCol);
            }

            for (char dig = '1'; dig <= '9'; dig++)
            {
                if (isSafe(board, row, col, dig))
                {
                    board[row][col] = dig;
                    if (SolveSudoku(board, nextRow, nextCol))
                        return true;
                    board[row][col] = '.';
                }
            }

            return false;
        }

        public static void main()
        {
            char[][] board =
                                    [
                                        ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                                        ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                                        ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                                        ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                                        ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                                        ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                                        ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                                        ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                                        ['.', '.', '.', '.', '8', '.', '.', '7', '9']
                                    ];

            SolveSudoku(board, 0, 0);
            foreach (var subset in board)
            {
                Console.WriteLine("[" + string.Join(", ", subset) + "]");
            }
        }
    }
}
