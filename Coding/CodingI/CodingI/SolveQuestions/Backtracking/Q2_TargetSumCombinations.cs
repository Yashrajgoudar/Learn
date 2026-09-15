using System.Linq;

namespace CodingI.SolveQuestions.Backtracking
{
    public class Q2_TargetSumCombinations
    {
        public static HashSet<string> uniqueValues = new HashSet<string>();
        public static void PrintCombinationsBruteForce(int[] arr, List<List<int>> ans, int tar, List<int> path, int i)
        {
            if (i >= arr.Length || tar < 0)
            {
                return;
            }
            if (tar == 0)
            {
                string key = string.Join(",", path);
                if (!uniqueValues.Contains(key))
                {
                    uniqueValues.Add(key);
                    ans.Add(new List<int>(path));
                }
                return;
            }
            path.Add(arr[i]);
            PrintCombinationsBruteForce(arr, ans, tar - arr[i], path, i + 1);
            PrintCombinationsBruteForce(arr, ans, tar - arr[i], path, i);
            path.RemoveAt(path.Count - 1);
            PrintCombinationsBruteForce(arr, ans, tar, path, i + 1);
        }

        public static void FindCombinationSumOptimized(int[] arr, IList<IList<int>> ans, List<int> comb, int start, int tar)
        {
            if (tar == 0)
            {
                ans.Add(new List<int>(comb));
                return;
            }

            for (int i = start; i < arr.Length; i++)
            {
                if (arr[i] > tar)
                {
                    break;

                }
                comb.Add(arr[i]);
                FindCombinationSumOptimized(arr, ans, comb, i, tar - arr[i]);    //Single Inclusion Call
                comb.RemoveAt(comb.Count - 1);  //Remove the included element while backtracking.
            }
        }

        public static void main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            IList<IList<int>> ans = new List<IList<int>>();
            //PrintCombinationsBruteForce(arr, ans, 5, [], 0);
            Array.Sort(arr);    //This step is important for this optimized solution
            FindCombinationSumOptimized(arr, ans, [],0, 5);

            foreach (var a in ans)
            {
                Console.WriteLine("[" + string.Join(", ", a) + "]");
            }
        }
    }
}
