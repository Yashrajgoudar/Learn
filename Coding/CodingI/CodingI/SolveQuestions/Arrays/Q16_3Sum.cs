namespace CodingI.SolveQuestions.Arrays
{
    // Function to find all unique triplets in an array that sum to zero
    public class Q16_3Sum
    {
        // Naive Approach with Time Complexity O(n^3) and Space Complexity O(1)
        public static List<List<int>> ThreeSumNaiveApproach(int[] arr, int target)
        {
            int n = arr.Length;
            List<List<int>> result = new List<List<int>>();
            for(int i = 0; i < n; i++)
            {
                for(int j=i+1;j< n; j++)
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == target)
                        {
                            List<int> triplet = new List<int> { arr[i], arr[j], arr[k] };
                            triplet.Sort();
                            // Check if the triplet is already present to avoid duplicates
                            if (!result.Any(r => r.SequenceEqual(triplet)))
                            {
                                result.Add(triplet);
                            }
                        }
                    }
                }
            }
            return result;
        }

        // HashSet Approach with Time Complexity O(n^2) and Space Complexity O(n)
        public static List<List<int>> ThreeSumHashSetApproach(int[] arr, int target)
        {
            int n = arr.Length;
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                HashSet<int> set = new HashSet<int>();
                for (int j = i + 1; j < n; j++)
                {
                    int second = target - arr[i] - arr[j];
                    if (set.Contains(second))
                    {
                        List<int> triplet = new List<int> { arr[i], arr[j], second };
                        triplet.Sort();
                        // Check if the triplet is already present to avoid duplicates
                        if (!result.Any(r => r.SequenceEqual(triplet)))
                        {
                            result.Add(triplet);
                        }
                    }
                    set.Add(arr[j]);
                }
            }
            return result;
        }

        // Two Pointer Approach with Time Complexity O(n^2) and Space Complexity O(1)
        public static List<List<int>> ThreeSumTwoPointer(int[] arr, int target)
        {
            int n = arr.Length;
            List<List<int>> result = new List<List<int>>();
            Array.Sort(arr); // Sort the array to use two-pointer technique
            for (int i = 0; i < n - 2; i++)
            {
                // Skip duplicates for the first element
                if (i > 0 && arr[i] == arr[i - 1]) continue;
                int left = i + 1;
                int right = n - 1;
                while (left < right)
                {
                    int sum = arr[i] + arr[left] + arr[right];
                    if (sum == target)
                    {
                        result.Add(new List<int> { arr[i], arr[left], arr[right] });
                        // Skip duplicates for the second element
                        while (left < right && arr[left] == arr[left + 1]) left++;
                        // Skip duplicates for the third element
                        while (left < right && arr[right] == arr[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return result;
        }
        public static void main(string[] args)
        {
            // Example usage of the ThreeSumNaiveApproach method
            int[] arr = [-1, 0, 1, 2, -1, -4];
            int target = 0;
            List<List<int>> triplets = ThreeSumNaiveApproach(arr, target);
            foreach (var triplet in triplets)
            {
                Console.WriteLine($"Triplet: {string.Join(", ", triplet)}");
            }
            List<List<int>> tripletHashSet = ThreeSumHashSetApproach(arr, target);
            foreach (var triplet in tripletHashSet)
            {
                Console.WriteLine($"Triplet Hash Set: {string.Join(", ", triplet)}");
            }
            List<List<int>> tripletTwoPointer = ThreeSumTwoPointer(arr, target);
            foreach (var triplet in tripletTwoPointer)
            {
                Console.WriteLine($"Triplet Two Pointer: {string.Join(", ", triplet)}");
            }
        }
    }
}
