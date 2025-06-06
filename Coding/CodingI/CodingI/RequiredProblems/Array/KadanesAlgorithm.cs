namespace CodingI.RequiredProblems.Array
{
    public class KadanesAlgorithm
    {
        public void PrintAllSubArrays(int[] arr)
        {
            //Loop to set pointer one 
            for(int start =0; start < arr.Length; start++)
            {
                //Loop to set pointer two
                for(int end = start; end < arr.Length; end++)
                {
                    //Loop to print the elements
                    for(int i = start; i <= end; i++)
                    {
                        Console.Write(arr[i]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public int BruteForceMaxSumSubArray(int[] arr)
        {
            int max = 0, sum = 0;
            for(int start = 0; start < arr.Length; start++)
            {
                for(int end=start;end< arr.Length; end++)
                {
                    for(int i = start; i <= end; i++)
                    {
                        sum += arr[i];
                    }
                    if(sum > max)
                    {                        
                        max = sum;
                    }
                    sum = 0;
                }
            }
            return max;
        }

        public int KadanesAlgorithmMaxSumSubArray(int[] arr)
        {
            int curSum = 0, maxSum = int.MinValue;
            for(int i = 0; i < arr.Length; i++)
            {
                curSum += arr[i];
                if(curSum > maxSum)
                {
                    maxSum = curSum;
                }
                if (curSum < 0)
                {
                    curSum = 0;
                }
            }
            return maxSum;
        }

        public static void main(string[] args)
        {
            int[] arr = { -2, 2};
            KadanesAlgorithm algorithm = new KadanesAlgorithm();
            algorithm.PrintAllSubArrays(arr);
            Console.WriteLine(algorithm.BruteForceMaxSumSubArray(arr));
            Console.WriteLine(algorithm.KadanesAlgorithmMaxSumSubArray(arr));
        }
    }
}
