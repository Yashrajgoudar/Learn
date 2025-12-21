namespace CodingI.SolveQuestions.Arrays
{
    internal class Q13MaximumProductSubarray
    {
        public static int MaximumProductSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int maxProd = nums[0];
            int minProd = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];

                // Swap if current number is negative
                if (current < 0)
                {
                    int temp = maxProd;
                    maxProd = minProd;
                    minProd = temp;
                }

                // Update max and min products
                maxProd = Math.Max(current, current * maxProd);
                minProd = Math.Min(current, current * minProd);

                // Update global result
                result = Math.Max(result, maxProd);
            }

            return result;
        }
        public static void main(string[] args)
        {
            int[] arr = { 2, 3, -2, 4 };
            int maxProd = MaximumProductSubArray(arr);
            Console.WriteLine("Maximum Product Subarray: " + maxProd);
        }
    }
}
