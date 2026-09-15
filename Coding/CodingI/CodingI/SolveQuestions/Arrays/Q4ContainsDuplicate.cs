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

        //Navie Approach has O(nlogn) Time Complexity
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

        //Best Approach has O(n) Time Complexity and Space Complexity O(n)
        public bool ContainsDuplicateHashSetApproach(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
            {
                if (set.Contains(num))
                    return true;

                set.Add(num);
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
