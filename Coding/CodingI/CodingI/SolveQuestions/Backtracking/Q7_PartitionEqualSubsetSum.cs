namespace CodingI.SolveQuestions.Backtracking
{
    public class Q7_PartitionEqualSubsetSum
    {
        //Time Complexity O(2^n) Space Complexity O(n)
        public static class FindPartitionSumREcursionApproach
        {
            public static bool IsPartitionSum(int[] arr, int n, int sum)
            {
                if (arr == null || n == 0) return false;

                if(sum == 0) return true;

                if (arr[n-1] > sum)
                    return IsPartitionSum(arr, n - 1, sum);

                return IsPartitionSum(arr, n - 1, sum - arr[n - 1]) || IsPartitionSum(arr, n - 1, sum);
            }

            public static bool FindPartitionSum(int[] arr)
            {
                int sum = 0;

                foreach (int i in arr)
                {
                    sum += i;
                }

                if (sum % 2 != 0)
                {
                    return false;
                }

                return IsPartitionSum(arr, arr.Length, sum / 2);
            }

        }

        //There are other approaches, get back to this question after learning Dynamic Programming
        public static void main()
        {
            int[] arr = [1, 5, 11, 5];

            Console.WriteLine(FindPartitionSumREcursionApproach.FindPartitionSum(arr));
        }
    }
}
