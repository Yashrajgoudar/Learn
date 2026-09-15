namespace CodingI.SolveQuestions.DynamicProgramming
{
    /*
        Q - House Robber II
      
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.

        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

 

        Example 1:

        Input: nums = [2,3,2]
        Output: 3
        Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.
        Example 2:

        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.
        Example 3:

        Input: nums = [1,2,3]
        Output: 3
     */
    public class Q16_HoueRobber2
    {
        //This question is similar to House Robber 1 with just one condition change.
        public static int Rob(int[] nums)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return nums[0];
            }

            // Case 1: Exclude last house
            int case1 = RobLinear(nums, 0, n - 2);

            // Case 2: Exclude first house
            int case2 = RobLinear(nums, 1, n - 1);

            return Math.Max(case1, case2);
        }

        public static int RobLinear(int[] nums, int start, int end)
        {
            int prev = 0;
            int prev2 = 0;

            for (int i = start; i <= end; i++)
            {
                int pick = nums[i] + prev2;
                int skip = prev;

                int curr = Math.Max(pick, skip);

                prev2 = prev;
                prev = curr;
            }

            return prev;
        }

        public static void main()
        {
            int[] nums = [2, 7, 9, 3, 1, 2];

            Console.WriteLine(Rob(nums));
        }
    }
}
