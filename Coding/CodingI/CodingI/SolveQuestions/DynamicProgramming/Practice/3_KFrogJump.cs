namespace CodingI.SolveQuestions.DynamicProgramming.Practice
{
    public class _3_KFrogJump
    {
        public static int MinJump(int[] heights, int n, int k)
        {
            if (n==0)
            {
                return 0;
            }

            int minValue=int.MaxValue;

            for(int i = 1; i <= k; i++)
            {
                int diff = int.MaxValue;
                if (n - i >= 0)
                {
                    diff = MinJump(heights, n - i, k) + Math.Abs(heights[n] - heights[n - i]);
                    minValue = Math.Min(minValue, diff);
                }
            }

            return minValue;
        }
        public static void main()
        {
            int[] heights = [30, 20, 50, 10, 40];
            int n = heights.Length;

            Console.WriteLine(MinJump(heights, n - 1, 2));
        }
    }
}
