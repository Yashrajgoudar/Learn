namespace CodingI.SolveQuestions.DynamicProgramming
{
    /*
        Q - House Robber
     
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

 

        Example 1:

        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.
        Example 2:

        Input: nums = [2,7,9,3,1]
        Output: 12
        Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
        Total amount you can rob = 2 + 9 + 1 = 12.
     */
    public class Q15_HouseRobber
    {   
        public static int Rob(int[] nums,int idx)
        {
            if (idx == 0)
            {
                return nums[idx];
            }

            if (idx < 0)
            {
                return 0;
            }
            int pick = nums[idx] + Rob(nums, idx - 2);
            int skip = Rob(nums, idx - 1);

            return Math.Max(pick, skip);
        }

        public static int RobMemoization(int[] nums, int idx, int[] dp)
        {
            if (idx == 0)
            {
                return nums[idx];
            }

            if (idx < 0)
            {
                return 0;
            }

            if (dp[idx] != -1)
            {
                return dp[idx];
            }
            int pick = nums[idx] + Rob(nums, idx - 2);
            int skip = Rob(nums, idx - 1);

            dp[idx] = Math.Max(pick, skip);

            return dp[idx];
        }

        public static int RobTabulation(int[] nums)
        {
            int n = nums.Length;
            int[] dp = Enumerable.Repeat(-1, n).ToArray();

            dp[0] = nums[0];

            for(int i = 1; i < n; i++)
            {
                int pick = nums[i];
                if (i > 1)
                {
                    pick += dp[i - 2];
                }

                int skip = 0 + dp[i - 1];

                dp[i] = Math.Max(pick, skip);
            }

            return dp[n-1];
        }

        public static int RobSpaceOptimized(int[] nums)
        {
            int n = nums.Length;
            int prev = nums[0];
            int prev2 = 0;

            for(int i = 1; i < n; i++)
            {
                int pick = nums[i] + prev2;
                int skip= 0 + prev;

                int curr=Math.Max(pick, skip);

                prev2 = prev;
                prev = curr;
            }

            return prev;
        }

        public static void PrintAllPaths(int[] nums, int idx, List<List<int>> ans, List<int> path)
        {

            if (idx >nums.Length-1)
            {
                ans.Add(new List<int>(path));
                return;
            }
            path.Add(nums[idx]);
            PrintAllPaths(nums, idx + 2, ans, path);
            path.Remove(nums[idx]);
            PrintAllPaths(nums, idx + 1, ans, path);
        }
        public static void main()
        {
            int[] nums = [2, 7, 9, 3, 1];
            int n = nums.Length;

            Console.WriteLine(Rob(nums, n-1));

            //List<List<int>> ans = new List<List<int>>();

            //PrintAllPaths(nums, 0, ans, new List<int>());

            //foreach (var subset in ans)
            //{
            //    Console.WriteLine("[" + string.Join(", ", subset) + "]");
            //}

            int[] dp = Enumerable.Repeat(-1, n).ToArray();



            Console.WriteLine(RobMemoization(nums, n - 1, dp));
            Console.WriteLine(RobTabulation(nums));
            Console.WriteLine(RobSpaceOptimized(nums));
        }

    }
}
