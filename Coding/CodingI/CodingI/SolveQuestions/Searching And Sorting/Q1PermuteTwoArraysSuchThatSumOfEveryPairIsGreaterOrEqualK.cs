namespace CodingI.SolveQuestions.Searching_And_Sorting
{
    internal class Q1PermuteTwoArraysSuchThatSumOfEveryPairIsGreaterOrEqualK
    {
        public static bool CanPermuteArrays(int[] a, int[] b, int k)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(b);
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] + b[i] < k)
                {
                    return false;
                }
            }
            return true;
        }
        public static void main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 5, 4, 1, 1, 1 };
            int k = 5;
            bool result = CanPermuteArrays(a, b, k);
            Console.WriteLine($"Can permute arrays such that sum of every pair is greater or equal to {k}: {result}");
        }
    }
}
