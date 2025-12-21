namespace CodingI.SolveQuestions.Arrays
{
    internal class Q15Find_PairWithSumInSorted_RotatedArray
    {
        // Function to find if there exists a pair of elements in a sorted and rotated array 
        // Naive HashSet Approach with Time Complexity O(n) and Space Complexity O(n)
        public static bool pairInSortedRotatedHashSetApproach(int[] arr, int target)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {

                // Calculate the complement that added to
                // arr[i], equals the target
                int complement = target - arr[i];

                // Check if the complement exists in the set
                if (set.Contains(complement))
                    return true;

                // Add the current element to the set
                set.Add(arr[i]);
            }
            // If no pair is found
            return false;
        }

        // Two Pointer Approach with Time Complexity O(n) and Space Complexity O(1)
        public static bool pairInSortedRotatedTwoPointerApproach(int[] arr, int target)
        {
            int n = arr.Length;

            // Find the pivot element
            int i;
            for (i = 0; i < n - 1; i++)
                if (arr[i] > arr[i + 1])
                    break;

            // l is now index of smallest element
            int l = (i + 1) % n;

            // r is now index of largest element
            int r = i;

            // Keep moving either l or r till they meet
            while (l != r)
            {

                // If we find a pair with sum target, return true
                if (arr[l] + arr[r] == target)
                    return true;

                // If current pair sum is less, move to higher sum
                if (arr[l] + arr[r] < target)
                    l = (l + 1) % n;

                // Move to lower sum side
                else
                    r = (r - 1 + n) % n;
            }
            return false;
        }


        public static void main(string[] args)
        {
            int[] arr = [11, 15, 6, 8, 9, 10];
            int target = 19;
            Console.WriteLine($"Pair with sum {target} exists: {pairInSortedRotatedHashSetApproach(arr, target)}");
            Console.WriteLine($"Pair with sum {target} exists: {pairInSortedRotatedTwoPointerApproach(arr, target)}");
        }
    }
}
