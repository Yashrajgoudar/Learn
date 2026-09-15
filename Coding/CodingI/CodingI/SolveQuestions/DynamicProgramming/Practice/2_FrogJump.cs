using System.Runtime.Intrinsics.Arm;

namespace CodingI.SolveQuestions.DynamicProgramming.Practice
{
    /*
        Q - Frog Jump - Climbing Stairs with Cost
        
        Given an integer array height[] where height[i] represents the height of the i-th stair, a frog starts from the first stair and wants to reach the last stair.
        From any stair i, the frog has two options: it can either jump to the (i+1)-th stair or the (i+2)-th stair.
        The cost of a jump is the absolute difference in height between the two stairs. Find the minimum total cost required for the frog to reach the last stair.

        Examples:

        Input: heights[] = [20, 30, 40, 20] 
        Output: 20
        Explanation:  Minimum cost is incurred when the frog jumps from stair 0 to 1 then 1 to 3:
        jump from stair 0 to 1: cost = |30 - 20| = 10
        jump from stair 1 to 3: cost = |20 - 30|  = 10
        Total Cost = 10 + 10 = 20

        Input: heights[] = [30, 20, 50, 10, 40]
        Output: 30
        Explanation: Minimum cost will be incurred when frog jumps from stair 0 to 2 then 2 to 4:
        jump from stair 0 to 2: cost = |50 - 30| = 20
        jump from stair 2 to 4: cost = |40 - 50|  = 10
        Total Cost = 20 + 10 = 30
     */
    public class _2_FrogJump
    {
        //Recursion
        public static int MinJump(int[] heights, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return Math.Abs(heights[n] - heights[n - 1]);
            }

            int left = MinJump(heights, n - 1) + Math.Abs(heights[n] - heights[n - 1]);
            int right = MinJump(heights, n - 2) + Math.Abs(heights[n] - heights[n - 2]);

            return Math.Min(left, right);
        }

        public static int MinJumpMemoization(int[] heights, int n, int[] dp)
        {
            if(n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return Math.Abs(heights[n]-heights[n - 1]);
            }

            if (dp[n] != -1)
            {
                return dp[n];
            }

            int left = MinJumpMemoization(heights, n - 1, dp) + Math.Abs(heights[n] - heights[n - 1]);
            int right = MinJumpMemoization(heights, n - 2, dp) + Math.Abs(heights[n] - heights[n - 2]);

            dp[n]=Math.Min(left, right);

            return dp[n];
        }

        public static int MinJumpTabulation(int[] heights)
        {
            int n = heights.Length;
            int[] dp = new int[n];
            dp[0] = 0;

            for(int i = 1; i < n; i++)
            {
                int fs = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
                int ls = int.MaxValue;
                if (i > 1)
                {
                    ls = dp[i - 2] + Math.Abs(heights[i] - heights[i - 2]);
                }
                dp[i]=Math.Min(fs, ls);
            }

            return dp[n-1];
        }

        public static int MinJumpSpaceOptimized(int[] heights)
        {
            int curr = 0;
            int prev = 0;
            int prev2 = 0;
            int n=heights.Length;

            for(int i = 1; i < n; i++)
            {
                int fs = prev + Math.Abs(heights[i] - heights[i - 1]);
                int ss= int.MaxValue;
                if(i > 1)
                {
                    ss = prev2 + Math.Abs(heights[i] - heights[i - 2]);
                }

                curr = Math.Min(fs, ss);
                prev2 = prev;
                prev = curr;
            }

            return prev;
        }

        public static void main()
        {
            int[] heights = [30, 20, 50, 10, 40];

            int n = heights.Length;
             
            int[] dp = Enumerable.Repeat(-1, n).ToArray();

            Console.WriteLine(MinJump(heights, n - 1));
            Console.WriteLine(MinJumpMemoization(heights, n - 1,dp));
            Console.WriteLine(MinJumpTabulation(heights));
            Console.WriteLine(MinJumpSpaceOptimized(heights));
        }
    }
}
