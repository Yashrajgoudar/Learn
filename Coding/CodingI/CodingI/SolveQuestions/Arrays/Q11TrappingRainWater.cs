namespace CodingI.SolveQuestions.Arrays
{
    internal class Q11TrappingRainWater
    {
        // Brute Force Approach to calculate trapped rain water with Time Complexity O(n^2) and Space Complexity O(1)
        public static int BruteForceTrappingRainWater(int[] arr)
        {
            int n = arr.Length;
            int height = 0;
            for(int i=0;i<n; i++)
            {
                int lmax = 0;
                int rmax = 0;
                for(int j = 0; j < i; j++)
                {
                    if (arr[j]>lmax)
                    {
                        lmax = arr[j];
                    }
                }
                for(int j=i;j<n; j++)
                {
                    if (arr[j]>rmax)
                    {
                        rmax = arr[j];
                    }
                }
                int maxHeight = Math.Min(lmax, rmax);
                if (maxHeight > arr[i])
                    height += Math.Min(lmax, rmax) - arr[i];
            }
            return height;
        }

        // Prefix Array Approach to calculate trapped rain water with Time Complexity O(n) and Space Complexity O(n)
        public static int PrefixArrayTrappingRainWater(int[] arr)
        {
            int n = arr.Length;
            if (n == 0) return 0;

            int[] leftMax = new int[n];
            int[] rightMax = new int[n];
            int height = 0;

            // Fill leftMax from left to right
            leftMax[0] = arr[0];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], arr[i]);
            }

            // Fill rightMax from right to left
            rightMax[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], arr[i]);
            }

            // Calculate total trapped water
            for (int i = 0; i < n; i++)
            {
                height += Math.Min(leftMax[i], rightMax[i]) - arr[i];
            }

            return height;
        }


        // Two Pointer Approach to calculate trapped rain water with Time Complexity O(n) and Space Complexity O(1)
        public static int TwoPointerTrappingRainWater(int[] arr)
        {
            int n = arr.Length;
            int left = 0, right = n - 1;
            int leftMax = 0, rightMax = 0;
            int height = 0;
            while (left < right)
            {
                leftMax=Math.Max(leftMax,arr[left]);
                rightMax=Math.Max(rightMax, arr[right]);
                if (leftMax<rightMax)
                {
                    height += leftMax - arr[left];
                    left++;
                }
                else
                {
                    height+= rightMax - arr[right];
                    right--;
                }
            }
            return height;
        }

        // Main method to test the implementations
        public static void main(string[] args)
        {
            int[] height = { 4,2,0,3,2,5 };
            Console.WriteLine(BruteForceTrappingRainWater(height));
            Console.WriteLine(PrefixArrayTrappingRainWater(height));
            Console.WriteLine(TwoPointerTrappingRainWater(height));
        }
    }
}
