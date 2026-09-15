namespace CodingI.SolveQuestions.Arrays
{
    public class Q20_MergeOverlappingIntervals
    {
        //Naive Approach 
        //Time Complexity O(n^2) and Space Complexity O(n)
        public static List<int[]> FindOverlappingIntervals(int[][] arr)
        {
            int n = arr.Length;

            Array.Sort(arr, (a, b) => a[0].CompareTo(b[0]));
            List<int[]> res = new List<int[]>();

            // Checking for all possible overlaps
            for (int i = 0; i < n; i++)
            {
                int start = arr[i][0];
                int end = arr[i][1];

                // Skipping already merged intervals
                if (res.Count > 0 && res[res.Count - 1][1] >= end)
                    continue;

                // Find the end of the merged range
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j][0] <= end)
                        end = Math.Max(end, arr[j][1]);
                }
                res.Add(new int[] { start, end });
            }
            return res;
        }

        // Optimized Solution
        //Time Complexity O(n*log(n)) and Space Complexity O(n)
        public static List<int[]> FindOverlappingIntervalsOptimized(int[][] arr)
        {
            if (arr.Length == 0) return new List<int[]>();

            // 1. Sort by start time
            Array.Sort(arr, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> result = new List<int[]>();

            int start = arr[0][0];
            int end = arr[0][1];

            for (int i = 1; i < arr.Length; i++)
            {
                // Overlap exists
                if (arr[i][0] <= end)
                {
                    end = Math.Max(end, arr[i][1]);
                }
                else
                {
                    result.Add(new int[] { start, end });
                    start = arr[i][0];
                    end = arr[i][1];
                }
            }

            // Add last interval
            result.Add(new int[] { start, end });

            return result;
        }

        public static void main(string[] args)
        {
            int[][] arr =
            {
                [7,8],
                [1,5],
                [2,4],
                [4,6]
            };

            List<int[]> overlappingIntervals = FindOverlappingIntervals(arr);
            List<int[]> overlappingIntervalsOptimized = FindOverlappingIntervalsOptimized(arr);

            foreach(int[] interval in overlappingIntervals)
            {
                Console.WriteLine(string.Join(", ", interval));
            }
            Console.WriteLine("---------------------");
            foreach (int[] interval in overlappingIntervalsOptimized)
            {
                Console.WriteLine(string.Join(", ", interval));
            }
        }
    }
}
