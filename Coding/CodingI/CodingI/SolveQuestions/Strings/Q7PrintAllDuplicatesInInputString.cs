namespace CodingI.SolveQuestions.Strings
{
    internal class Q7PrintAllDuplicatesInInputString
    {
        // Dictionary Approach will provide the solution but will not preserve the order of characters in the input string.
        // Time Complexity is O(n) where n is the length of the input string and Space Complexity is O(k) where k is the number of unique characters in the string.
        public static Dictionary<char,int> PrintAllDuplicates(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (result.ContainsKey(c))
                {
                    result[c]++;
                }
                else
                {
                    result[c] = 1;
                }
            }
            return result;
        }

        // Sorting Approach will preserve the order of characters in the input string.
        // Time Complexity is O(n log n) due to sorting and Space Complexity is O(1) if we ignore the input string.
        public static void printDuplicatesSortingApproach(string s)
        {
            char[] sortedChar = s.ToCharArray();
            Array.Sort(sortedChar);
            for (int i = 0; i < sortedChar.Length;)
            {
                int count = 1;
                while (i + count < sortedChar.Length && sortedChar[i] == sortedChar[i + count])
                {
                    count++;
                }
                if (count > 1)
                {
                    Console.WriteLine($"Character: {sortedChar[i]}, Count: {count}");
                }
                i += count;
            }
        }
        public static void main(string[] args)
        {
            string input = "geeksforgeeks";
            Dictionary<char, int> duplicates = PrintAllDuplicates(input);
            Console.WriteLine("Duplicate characters in the input string:");
            foreach (var kvp in duplicates)
            {
                if (kvp.Value > 1)
                {
                    Console.WriteLine($"Character: {kvp.Key}, Count: {kvp.Value}");
                }
            }
            Console.WriteLine("Duplicate characters using sorting approach:");
            printDuplicatesSortingApproach(input);
        }
    }
}
