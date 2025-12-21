using System.Text;

namespace CodingI.SolveQuestions.Strings
{
    internal class Q5LongestCommonPrefix
    {
        //Vertical Scanning Approach with Time Complexity O(n*m) where n is the number of strings and m is the length of the shortest string.
        public static string FindLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                char currentChar = strs[0][i];

                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != currentChar)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }

            return strs[0];
        }

        //Sorting-Based Approach with Time Complexity O(n*m log n) where n is the number of strings and m is the length of the shortest string.
        public static string FindLongestCommonPrefixSorting(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";
            Array.Sort(strs);
            string first = strs[0];
            string last = strs[strs.Length - 1];
            int i = 0;
            while (i < first.Length && i < last.Length && first[i] == last[i])
            {
                i++;
            }
            return first.Substring(0, i);
        }
        public static void main(string[] args)
        {
            string[] strs = ["flower", "flow", "flight"];
            Console.WriteLine(FindLongestCommonPrefix(strs));
            Console.WriteLine(FindLongestCommonPrefixSorting(strs));
        }
    }
}
