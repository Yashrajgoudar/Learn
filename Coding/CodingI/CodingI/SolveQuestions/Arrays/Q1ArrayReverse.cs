namespace CodingI.SolveQuestions.Arrays
{
    public class Q1ArrayReverse
    {
        //Naive Approach Time Complexity: O(n);  Space Complexity: O(n)
        public int[] ReverseArray(int[] arr)
        {
            int[] reversedArray = new int[arr.Length];
            int j = 0;
            for(int i = arr.Length - 1; i >=0; i--)
            {
                reversedArray[j] = arr[i]; 
                j++;
            }
            return reversedArray;
        }


        //Optimized Array Reversal Solution Time Complexity: O(n); Space Complexity: O(1)
        public int[] OptimizedReverseArray(int[] arr)
        {
            int i = 0, j = arr.Length-1;
            while (i < j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
            return arr;
        }

        public static void main(string[] args)
        {
            int[] arr = { 3, 6, 2, 8, 4, 5 };
            Q1ArrayReverse arrayReverse = new Q1ArrayReverse();
            Console.WriteLine(string.Join(", ", arrayReverse.ReverseArray(arr)));
            Console.WriteLine(string.Join(", ", arrayReverse.OptimizedReverseArray(arr)));
        }
    }
}
