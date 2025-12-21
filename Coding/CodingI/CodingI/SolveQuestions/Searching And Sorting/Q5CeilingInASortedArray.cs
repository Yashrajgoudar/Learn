namespace CodingI.SolveQuestions.Searching_And_Sorting
{
    internal class Q5CeilingInASortedArray
    {
        /* Function to get index of ceiling of x in arr */
        public static int CeilSearchLinear(int[] arr, int x)
        {
            /* If x is smaller than or equal to first element, 
                then return the first element */
            if (x <= arr[0])
                return 0;

            /* Otherwise, linearly search for ceil value */
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == x)
                    return i;

                /* if x lies between arr[i] and arr[i+1] including 
                arr[i+1], then return arr[i+1] */
                if (arr[i] < x && arr[i + 1] >= x)
                    return i + 1;
            }
            /* If we reach here then x is greater than the last element 
                of the array, return -1 in this case */
            return -1;
        }
        // Function to find the ceiling of a given number in a sorted array
        public static int CeilSearchBinary(int[] arr, int x)
        {
            int lo = 0, hi = arr.Length - 1, res = -1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] < x)
                    lo = mid + 1;

                else
                { // Potential ceiling found
                    res = mid;
                    hi = mid - 1;
                }
            }
            return res;
        }
        public static void main(string[] args)
        {
            int[] arr = { 1, 2, 8, 10, 10, 12, 19 };
            int x = 5;
            int ceiling = CeilSearchBinary(arr, x);
            Console.WriteLine($"The ceiling of {x} in the array is: {ceiling}");
            // Example usage of CeilSearch
            int index = CeilSearchLinear(arr, x);
            Console.WriteLine($"The ceiling of {x} in the array is: {index}");
        }
    }
}
