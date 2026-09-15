namespace CodingI.SolveQuestions.Backtracking
{
    public class Q1_BacktrackingSet2RatInAMaze
    {
        public static void PrintPath(int[][] maze,int row,int col, List<string> ans,string path, bool[][] vis)
        {
            if(row<0||col<0||row>=maze.Length || col >= maze.Length || maze[row][col] == 0 || vis[row][col]==true)
            {
                return;
            }
            if (row==maze.Length-1 && col == maze.Length - 1)
            {
                ans.Add(path);
                return;
            }

            vis[row][col] = true;
            PrintPath(maze, row + 1, col, ans, path + 'D', vis);
            PrintPath(maze, row, col - 1, ans, path + 'L', vis);
            PrintPath(maze, row, col + 1, ans, path + 'R', vis);
            PrintPath(maze, row - 1, col, ans, path + 'U', vis);
            vis[row][col] = false;
        }


        //If we want to find out if there exists any solution and not all possible solutions then we need to use this bool approach.
        public static bool FindPath(int[][] maze, int row, int col, string path, bool[][] vis)
        {
            // Boundary + invalid checks
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length
                || maze[row][col] == 0 || vis[row][col])
            {
                return false;
            }

            // Destination reached
            if (row == maze.Length - 1 && col == maze[0].Length - 1)
            {
                Console.WriteLine(path); // print first valid path
                return true;
            }

            vis[row][col] = true;

            // Explore all directions (stop when one succeeds)
            if (FindPath(maze, row + 1, col, path + 'D', vis)) return true;
            if (FindPath(maze, row, col - 1, path + 'L', vis)) return true;
            if (FindPath(maze, row, col + 1, path + 'R', vis)) return true;
            if (FindPath(maze, row - 1, col, path + 'U', vis)) return true;

            vis[row][col] = false; // backtrack

            return false;
        }


        public static void main(string[] args)
        {
            int[][] maze = [[1,0,0,0],
                            [1,1,0,1],
                            [1,1,0,0],
                            [0,1,0,1]];

            bool[][] vis = new bool[maze.Length][];

            for(int i = 0; i < maze.Length; i++)
            {
                vis[i]=new bool[maze[i].Length];
            }

            List<string> ans = new List<string>();

            PrintPath(maze, 0, 0, ans, "", vis);

            foreach (string s in ans)
            {
                Console.WriteLine(s);
            }

            bool found = FindPath(maze, 0, 0, "", vis);

            if (!found)
                Console.WriteLine("No path found");
        }
    }
}
