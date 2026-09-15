namespace CodingI.SolveQuestions.DynamicProgramming
{
    public class Q5_ClimbingStairs
    {
        public static int FindMaxStairsRecursive(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            return FindMaxStairsRecursive(n - 1) + FindMaxStairsRecursive(n - 2);
        }

        public static int FindMaxStairsMemoization(int n, int[] dp)
        {
            if(n <= 2)
            {
                return n;
            }
            if (dp[n] != -1)
            {
                return dp[n];
            }

            dp[n] = FindMaxStairsMemoization(n - 1, dp) + FindMaxStairsMemoization(n - 2, dp);

            return dp[n];
        }

        public static int FindMaxStairsTabulation(int n, int[] dp)
        {
            if (n <= 2)
            {
                return n;
            }
            dp[0] = 1;
            dp[1] = 2;

            for(int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        public static int FindMaxStairsOptimized(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            int prev2 = 1;
            int prev1 = 2;
            for(int i = 2; i < n; i++)
            {
                int curr = prev2 + prev1;
                prev2 = prev1;
                prev1= curr;
            }

            return prev1;
        }
        public static void main()
        {
            int n = 2;
            int[] dp = Enumerable.Repeat(-1, n + 1).ToArray();
            Console.WriteLine(FindMaxStairsRecursive(n));
            Console.WriteLine(FindMaxStairsMemoization(n, dp));
            Console.WriteLine(FindMaxStairsTabulation(n, dp));
            Console.WriteLine(FindMaxStairsOptimized(n));
        }
    }
}
