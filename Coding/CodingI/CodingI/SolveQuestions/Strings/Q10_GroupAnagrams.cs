using System.Text;

namespace CodingI.SolveQuestions.Strings
{
    internal class Q10_GroupAnagrams
    {
        // Naive approach to group anagrams from a list of strings
        // Time Complexity: O(n * m log m), where n is the number of strings and m is the maximum length of a string
        // Space Complexity: O(n * m), where n is the number of strings and m is the maximum length of a string
        public static List<List<string>> AnagramsNaiveApproach(string[] arr)
        {
            List<List<string>> res = new List<List<string>>();
            Dictionary<string, int> mp = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                string s = arr[i];

                // Find the key by sorting the string
                char[] charArray = s.ToCharArray();
                Array.Sort(charArray);
                s = new string(charArray);

                // If key is not present in the hash map, add
                // an empty group (list) in the result and
                // store the index of the group in hash map
                if (!mp.ContainsKey(s))
                {
                    mp[s] = res.Count;
                    res.Add(new List<string>());
                }

                // Insert the string in its correct group
                res[mp[s]].Add(arr[i]);
            }

            return res;
        }

        public class AnagramsFreqAsKeysApproach
        {
            const int MAX_CHAR = 26;

            // Function to generate hash of word s
            public static string GetHash(string s)
            {
                StringBuilder hash = new StringBuilder();
                int[] freq = new int[MAX_CHAR];

                // Count frequency of each character
                foreach (char ch in s)
                {
                    freq[ch - 'a'] += 1;
                }

                // Append the frequency to construct the hash
                for (int i = 0; i < MAX_CHAR; i++)
                {
                    hash.Append(freq[i].ToString());
                    hash.Append("$");
                }

                return hash.ToString();
            }

            public static List<List<string>> Anagrams(string[] arr)
            {
                List<List<string>> res = new List<List<string>>();
                Dictionary<string, int> mp = new Dictionary<string, int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    string key = GetHash(arr[i]);

                    // If key is not present in the hash map, add
                    // an empty group (List) in the result and
                    // store the index of the group in hash map
                    if (!mp.ContainsKey(key))
                    {
                        mp[key] = res.Count;
                        res.Add(new List<string>());
                    }

                    // Insert the string in its correct group
                    res[mp[key]].Add(arr[i]);
                }

                return res;
            }
        }
        public static void main(string[] args)
        {
            string[] arr = { "eat", "tea", "tan", "ate", "nat", "bat" };
            List<List<string>> result = AnagramsNaiveApproach(arr);
            Console.WriteLine("Grouped Anagrams:");
            foreach (var group in result)
            {
                Console.WriteLine(string.Join(", ", group));
            }

            // Using frequency as keys approach
            List<List<string>> resultFreq = AnagramsFreqAsKeysApproach.Anagrams(arr);
            Console.WriteLine("Grouped Anagrams using frequency as keys:");
            foreach (var group in resultFreq)
            {
                Console.WriteLine(string.Join(", ", group));
            }
        }
    }
}
