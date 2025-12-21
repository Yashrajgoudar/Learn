namespace CodingI.SolveQuestions.Searching_And_Sorting
{
    internal class Q4SearchingInArrayAdjacentDifferByK
    {
        // x is the element to be searched 
        // in arr[0..n-1] such that all 
        // elements differ by at-most k.
        public static int search(int[] arr, int n,int x, int k)
        {
            // Traverse the given array starting
            // from leftmost element
            int i = 0;

            while (i < n)
            {

                // If x is found at index i
                if (arr[i] == x)
                    return i;

                // Jump the difference between 
                // current array element and x
                // divided by k We use max here
                // to make sure that i moves 
                // at-least one step ahead.
                i = i + Math.Max(1, Math.Abs(arr[i]
                                        - x) / k);
            }

            Console.Write("number is " +
                          "not present!");
            return -1;
        }
        public static void main(string[] args)
        {
            int[] arr = { 2, 4, 5, 7, 7, 6 };
            int x = 6;
            int k = 2;
            int n = arr.Length;

            Console.Write("Element " + x +
                          " is present at index " +
                            search(arr, n, x, k));
        }
    }
}
