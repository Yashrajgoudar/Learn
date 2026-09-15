namespace CodingI.SolveQuestions.Arrays
{
    /*Question
        
        Given an array of integers arr[], the task is to find the maximum and minimum elements in the array using the minimum number of comparisons.

        Examples:

        Input: arr[] = [3, 5, 4, 1, 9]
        Output: [1, 9]
        Explanation: The minimum element is 1, and the maximum element is 9.

        Input: arr[] = [22, 14, 8, 17, 35, 3]
        Output: [3, 35] 
        Explanation: The minimum element is 3, and the maximum element is 35.
     */
    public class Q1_MaximumAndMinimumArray
    {
        //This is a Naive solution and uses and 2 * (n - 1) comparisons
        public (int max, int min) FindMaximumAndMinimum(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array cannot be null or empty.");
            int arrayMin = arr[0];
            int arrayMax = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > arrayMax)
                {
                    arrayMax = arr[i];
                }
                if(arr[i] < arrayMin)
                {
                    arrayMin = arr[i];
                }
            }
            return (arrayMax, arrayMin);
        }

        // Method to find both maximum and minimum in an array using minimal comparisons 1.5(n - 1)
        public (int max, int min) OptimizedFindMaximumAndMinimum(int[] arr)
        {
            // Step 1: Handle null or empty arrays
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array cannot be null or empty.");

            int min, max;
            int i; // Index to track current position in loop

            // Step 2: If array has even number of elements
            if (arr.Length % 2 == 0)
            {
                // Compare the first two elements to initialize min and max
                if (arr[0] > arr[1])
                {
                    max = arr[0];
                    min = arr[1];
                }
                else
                {
                    max = arr[1];
                    min = arr[0];
                }

                // Start from the third element (index 2) since first two are already considered
                i = 2;
            }
            else
            {
                // If odd, initialize both min and max with the first element
                min = max = arr[0];

                // Start from the second element (index 1)
                i = 1;
            }

            // Step 3: Process remaining elements in pairs
            while (i < arr.Length - 1)
            {
                int localMin, localMax;

                // Compare the current pair: arr[i] and arr[i+1]
                if (arr[i] > arr[i + 1])
                {
                    localMax = arr[i];
                    localMin = arr[i + 1];
                }
                else
                {
                    localMax = arr[i + 1];
                    localMin = arr[i];
                }

                // Compare localMax with current max
                if (localMax > max) max = localMax;

                // Compare localMin with current min
                if (localMin < min) min = localMin;

                // Move to the next pair
                i += 2;
            }

            // Step 4: Return result as a tuple (max, min)
            return (max, min);
        }
        public static void main(string[] args)
        {
            int[] arr = {3,6,2,8,4,5};
            Q1_MaximumAndMinimumArray maximumAndMinimumArray = new Q1_MaximumAndMinimumArray();
            var result = maximumAndMinimumArray.FindMaximumAndMinimum(arr);
            var optimizedResult = maximumAndMinimumArray.OptimizedFindMaximumAndMinimum(arr);
            Console.WriteLine(result);
            Console.WriteLine(optimizedResult);
        }
    }

}
