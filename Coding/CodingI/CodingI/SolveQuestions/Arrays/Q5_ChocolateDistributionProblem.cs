namespace CodingI.SolveQuestions.Arrays
{
    public class Q5_ChocolateDistributionProblem
    {
        public static int FindMinDif(int[] arr,int m)
        {
            Array.Sort(arr);
            int l = 0, r = m - 1;
            int minDiff = arr[r] - arr[l];
            while (r < arr.Length)
            {
                int diff=arr[r] - arr[l];
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
                l++;
                r++;
            }
            return minDiff;
        }
        public static void main()
        {
            int[] arr = { 7, 3, 2, 4, 9, 12, 56 };
            int res = FindMinDif(arr,3);
            Console.WriteLine(res);
        }
    }
}
