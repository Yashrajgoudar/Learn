namespace CodingI.SolveQuestions.Arrays
{
    internal class Q12ArrayProductExceptItself
    {
        // Brute Force Approach to calculate product of array except itself with Time Complexity O(n^2) and Space Complexity O(n)
        public static int[] BruteForceArrayProduct(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            for(int i = 0; i < n; i++)
            {
                int prod = 1;
                for(int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    prod *= arr[j];
                }
                result[i] = prod;
            }            
            return result;
        }

        // Optimized Approach to calculate product of array except itself with Time Complexity O(n) and Space Complexity O(n)
        public static int[] OptimizedArrayProduct(int[] arr)
        {
            int n = arr.Length;
            int[] prefix = new int[n];
            int[] suffix = new int[n];
            int[] result = new int[n];
            prefix[0] = 1;
            suffix[n - 1] = 1;

            // Fill prefix arrays
            for (int i = 1; i < n; i++)
            {
                prefix[i] = prefix[i - 1] * arr[i - 1];
            }

            // Fill suffix array
            for (int i = n - 2; i >= 0; i--)
            {
                suffix[i] = suffix[i + 1] * arr[i + 1];
            }

            // Calculate result by multiplying prefix and suffix arrays
            for (int i = 0; i < n; i++)
            {
                result[i] = prefix[i] * suffix[i];
            }
            return result;
        }

        // Further Optimized Approach to calculate product of array except itself with Time Complexity O(n) and Space Complexity O(1)
        public static int[] OptimizedArrayProduct2(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            result[0] = 1;
            for (int i=1; i < n; i++)
            {
                result[i] = result[i-1] * arr[i-1];
            }

            int suffix = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                suffix *= arr[i + 1];
                result[i] *= suffix;
            }
            return result;
        }

        // Main method to test the functionality
        public static void main(string[] args)
        {
            int[] arr = [1, 2, 3, 4];
            int[] result = BruteForceArrayProduct(arr);
            int[] result1 = OptimizedArrayProduct(arr);
            int[] result2 = OptimizedArrayProduct2(arr);
            Console.WriteLine("[" + string.Join(", ", result) + "]");
            Console.WriteLine("[" + string.Join(", ", result1) + "]");
            Console.WriteLine("[" + string.Join(", ", result2) + "]");
        }
    }
}
