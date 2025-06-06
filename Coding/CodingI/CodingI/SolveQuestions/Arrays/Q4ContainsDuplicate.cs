namespace CodingI.SolveQuestions.Arrays
{
    public class Q4ContainsDuplicate
    {
        //Navie Approach has O(n²) Time Complexity
        public bool ContainsDuplicate(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsDuplicateOptimized(int[] arr)
        {
            Array.Sort(arr);
            for(int i = 1;i < arr.Length; i++)
            {
                if(arr [i] == arr[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        public static void main(string[] args)
        {
            int[] arr = { 3, 6, 3, 8, 4, 5 };
            Q4ContainsDuplicate containsDuplicate = new Q4ContainsDuplicate();
            Console.WriteLine(containsDuplicate.ContainsDuplicate(arr));
            Console.WriteLine(containsDuplicate.ContainsDuplicateOptimized(arr));
        }
    }
}
