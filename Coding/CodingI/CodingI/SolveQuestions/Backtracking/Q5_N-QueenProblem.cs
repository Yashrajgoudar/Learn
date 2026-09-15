using CodingI.RequiredProblems.Recursion;

namespace CodingI.SolveQuestions.Backtracking
{
    public class Q5_N_QueenProblem
    {
        public static bool isSafe(char[][] board, int row, int col, int n)
        {
            //vertical check
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 'Q')
                    return false;
            }

            //upper left diagonal check
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                if (board[i][j] == 'Q')
                    return false;

            //lower left diagonal check
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                if (board[i][j] == 'Q')
                    return false;
            return true;
        }

        public static void GetNQueens(char[][] board, int row, int n, IList<IList<string>> ans)
        {
            if (row == n)
            {
                var solution = new List<string>();
                foreach (var r in board)
                    solution.Add(new string(r));
                ans.Add(solution);
                return;
            }
            for (int col = 0; col < n; col++)
            {
                if (isSafe(board, row, col, n))
                {
                    board[row][col] = 'Q';
                    GetNQueens(board, row + 1, n, ans);
                    board[row][col] = '.';
                }
            }
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            char[][] board = new char[n][];
            IList<IList<string>> ans = new List<IList<string>>();
            for (int i = 0; i < n; i++)
            {
                board[i] = new string('.', n).ToCharArray();
            }
            GetNQueens(board, 0, n, ans);
            return ans;
        }

        public static void main()
        {
            int n = 4;
            IList<IList<string>> allValidNQueens = [];
            var nQueensResult = SolveNQueens(n);
            foreach (var subset in nQueensResult)
            {
                Console.WriteLine("[" + string.Join(", ", subset) + "]");
            }
        }
    }
}
