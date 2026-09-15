namespace CodingI.SolveQuestions.Backtracking
{
    public class Q4_LongestPossibleRouteInMatrixWithHurdles
    {
        public static int SolveHurdle(int[][] mat, int i, int j, int x, int y, bool[][] vis, int currLength)
        {
            if (i < 0 || j < 0 || i>=mat.Length || j >= mat[0].Length || vis[i][j] || mat[i][j]==0)
            {
                return -1;
            }

            if(i==x && j == y)
            {
                return 0;
            }


            vis[i][j] = true;
            int down = SolveHurdle(mat, i + 1, j, x, y, vis, currLength + 1);  //Down
            int left = SolveHurdle(mat, i, j - 1, x, y, vis, currLength + 1);  //Left
            int right = SolveHurdle(mat, i, j + 1, x, y, vis, currLength + 1);  //Right
            int up = SolveHurdle(mat, i - 1, j, x, y, vis, currLength + 1);  //Up
            vis[i][j] = false;

            int maxPath = Math.Max(Math.Max(down, up), Math.Max(left, right));

            if(maxPath== -1) return -1;

            return maxPath + 1;
        }
        public static void main()
        {
            //int[][] mat = [ [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
            //       [1, 1, 0, 1, 1, 0, 1, 1, 0, 1],
            //       [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]];

            int[][] mat = [ [1,1,1],
                            [1,0,1],
                            [1,1,1]];

            int xs = 0, ys = 0;
            int xd = 0, yd = 2;

            bool[][] vis = new bool[mat.Length][];

            for (int i = 0; i < mat.Length; i++)
            {
                vis[i] = new bool[mat[0].Length];
            }

            Console.WriteLine(SolveHurdle(mat, xs, ys, xd, yd, vis, 0));
        }
    }
}
