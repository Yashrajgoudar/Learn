namespace CodingI.SolveQuestions.Arrays
{
    internal class Q14MinimumRotatedSortedArray
    {
        // Brute Force Approach to find minimum in a rotated sorted array with Time Complexity O(n) and Space Complexity O(1)
        public static int BruteForceFindMinimum(int[] arr)
        {
            int n = arr.Length;
            int min = arr[0];
            for (int i = 0; i < n; i++)
            {
                if (arr[i]<min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        // Optimized Approach to find minimum in a rotated sorted array using Binary Search with Time Complexity O(log n) and Space Complexity O(1)
        public static int OptimizedFindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[right])
                {
                    // Min is in the right half
                    left = mid + 1;
                }
                else
                {
                    // Min is in the left half including mid
                    right = mid;
                }
            }

            // left == right, which is the index of the minimum
            return nums[left];
        }

        public static void main(string[] args)
        {
            int[] arr = { 11, 13, 15, 17 };
            int min = BruteForceFindMinimum(arr);
            int min2 = OptimizedFindMin(arr);
            Console.WriteLine("Minimum Element in Rotated Sorted Array: "+min);
            Console.WriteLine("Minimum Element in Rotated Sorted Array: "+min2);
        }
    }
}
