namespace CodingI.SolveQuestions.Arrays
{
    public class Q9RepeatAndMissingNumberArray
    {
        //Brute Force Method with Time Complexity O(n²)
        public static List<int> FindRepeatAndMissing(List<int> arr)
        {
            int n = arr.Count;
            int miss=0;
            int rep=0;
            for(int i = 1; i <= n; i++)
            {
                bool flag=false;
                int count=0;
                foreach(int j in arr)
                {
                    if (j == i)
                    {
                        flag=true;
                        count++;
                    }
                }
                if (count == 2)
                {
                    rep = i;
                }
                if (!flag)
                {
                    miss = i;
                }
            }
            List<int> result = new List<int>();
            result.Add(rep);
            result.Add(miss);
            return result;
        }


        //Optimized Solution with Time Complexity O(n)
        public static List<int> OptimizedFindRepeatAndMissing(List<int> arr)
        {
            int n = arr.Count;
            int natural_sum = n * (n + 1) / 2;
            int natural_sq_sum = n * (n + 1) * (2 * n + 1) / 6;
            int aq_sum = 0, aq_sq_sum = 0;
            foreach(int i in arr)
            {
                aq_sum += i;
                aq_sq_sum += i * i;
            }
            int diff = natural_sum - aq_sum; // x - y
            int sq_diff = natural_sq_sum - aq_sq_sum;  // x^2 - y^2 = (x - y)(x + y)
            int sumXY = sq_diff / diff;  // x + y
            int x = (diff + sumXY) / 2;  // missing number
            int y = x - diff;  // repeating number
            return new List<int> { y, x };
        }
        public static void main(string[] args)
        {
            List<int> arr = new List<int> { 1,2 , 3, 1, 5 };
            List<int> result = OptimizedFindRepeatAndMissing(arr);
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
    }
}
