namespace CodingI.SolveQuestions.Arrays
{
    public class Q17_ContainerWithMostWater
    {
        // Brute Force Approach to find the maximum area of water that can be contained
        // Time Complexity: O(n^2), Space Complexity: O(1)
        public static int MaxAreaTwoPointer(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            int maxArea = 0;
            while (left < right)
            {
                int h=Math.Min(arr[left], arr[right]);
                int w = right - left;
                int area = h * w;
                if (area > maxArea)
                {
                    maxArea = area;
                }
                if (arr[left] < arr[right])
                    left++;
                else
                    right--;
            }
            return maxArea;
        }
        // Two Pointer Approach to find the maximum area of water that can be contained
        // Time Complexity: O(n), Space Complexity: O(1)
        public static int MaxAreaBruteForce(int[] arr)
        {
            int n = arr.Length;
            int maxArea = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    int h = Math.Min(arr[i], arr[j]);
                    int w = j - 1;
                    int are = h * w;
                    if(are > maxArea)
                    {
                        maxArea = are;
                    }
                }
            }
            return maxArea;
        }
        public static void main(string[] args)
        {
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine("Maximum area of water that can be contained using Brute Force Approach: " + MaxAreaBruteForce(heights));
            Console.WriteLine("Maximum area of water that can be contained using Two Pointer Approach: " + MaxAreaTwoPointer(heights));
        }
    }
}
