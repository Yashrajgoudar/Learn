namespace CodingI.SolveQuestions.Searching_And_Sorting
{
    internal class Q6PiarWithGivenDifference
    {
        // Function to find if there exists a pair with the given difference Naive Approach with Time Complexity O(n^2) and Space Complexity O(1)
        public static bool PairWithDifferenceNaive(int[] arr, int k)
        {
            for(int i=0;i<arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (Math.Abs(arr[j] - arr[i]) == k)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Function to find if there exists a pair with the given difference using Two Pointer Approach with Time Complexity O(n log n) and Space Complexity O(1)
        public static bool PairWithDifferenceTwoPointer(int[] arr, int x)
        {
            int n = arr.Length;

            // Sort the array.
            Array.Sort(arr);

            int j = 1;

            for (int i = 0; i < n; i++)
            {

                // Increment j till difference is 
                // less than x.
                while (j < n && arr[j] - arr[i] < x) j++;

                // If difference is x
                if (j < n && i != j && arr[j] - arr[i] == x) return true;
            }

            return false;
        }

        // Function to find if there exists a pair with the given difference using HashSet Approach with Time Complexity O(n) and Space Complexity O(n)
        public static bool PairWithDifferenceHashSet(int[] arr, int x)
        {
            HashSet<int> st = new HashSet<int>();

            foreach (int num in arr)
            {

                // Check if complement exists
                if (st.Contains(num + x) || st.Contains(num - x))
                {
                    return true;
                }

                st.Add(num);
            }

            return false;
        }

        // Function to find if there exists a pair with the given difference using Binary Search Approach with Time Complexity O(n log n) and Space Complexity O(1)
        public class PairWithDifferenceBinarySearchApproach
        {
            // Function to find a pair with the given difference
            public static bool findPair(int[] arr, int x)
            {

                // Sort the array first
                Array.Sort(arr);

                int n = arr.Length;

                // For each element, search for its complement
                for (int i = 0; i < n; i++)
                {

                    // Try finding arr[i] + x
                    int target = arr[i] + x;

                    // Binary search for target
                    if (binarySearch(arr, i + 1, n - 1, target))
                    {
                        return true;
                    }
                }

                return false;
            }

            // Binary search function
            static bool binarySearch(int[] arr, int left, int right, int key)
            {
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (arr[mid] == key)
                    {
                        return true;
                    }
                    else if (arr[mid] < key)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return false;
            }
        }

        public static void main(string[] args)
        {
            int[] arr = { 5, 10, 3, 2, 50, 80 };
            int k = 78;
            Console.WriteLine($"Pair with difference {k} exists: {PairWithDifferenceNaive(arr, k)}");
            Console.WriteLine($"Pair with difference {k} exists using binary search: {PairWithDifferenceBinarySearchApproach.findPair(arr, k)}");
            Console.WriteLine($"Pair with difference {k} exists using two pointer approach: {PairWithDifferenceTwoPointer(arr, k)}");
            Console.WriteLine($"Pair with difference {k} exists using hashset approach: {PairWithDifferenceHashSet(arr, k)}");
        }
    }
}
