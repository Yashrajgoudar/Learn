namespace CodingI.SolveQuestions.Arrays
{
    public class Q7NextPermutation
    {
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public static void FindNextPermutation(int[] arr)
        {
            int n = arr.Length;
            int pivot = -1;
            for(int i = n - 2; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    pivot = i;
                    break;
                }
            }

            if (pivot == -1)
            {
                Array.Sort(arr);
                return;
            }

            for(int i = n-1; i >pivot; i--)
            {
                if (arr[i] > arr[pivot])
                {
                    (arr[i], arr[pivot]) = (arr[pivot], arr[i]);
                    break;
                }
            }

            int k = pivot + 1, j = n - 1;
            while (k <= j)
            {
                (arr[k], arr[j]) = (arr[j], arr[k]);
                k++; j--;
            }
        }

        public static void main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            FindNextPermutation(arr);
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
    }
}
