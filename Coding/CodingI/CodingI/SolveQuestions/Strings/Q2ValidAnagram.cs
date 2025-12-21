namespace CodingI.SolveQuestions.Strings
{
    public class Q2ValidAnagram
    {
        // Check if two strings are anagrams of each other using a dictionary approach with Time Complexity O(n) and Space Complexity O(1) since the dictionary size is constant (26 letters).
        public static bool IsAnagramDictionaryApproach(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }
            
            foreach(char c in t)
            {
                if(!charCount.ContainsKey(c) || charCount[c] == 0)
                    return false;
                charCount[c]--;
            }
            return true;
        }

        // Check if two strings are anagrams of each other using an array approach with Time Complexity O(n) and Space Complexity O(1) since the array size is constant (26 letters).
        public static bool IsAnagramArrayApproach(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            int[] charCount = new int[26];
            for(int i=0;i<s.Length; i++)
            {
                charCount[s[i] - 'a']++;
                charCount[t[i] - 'a']--;
            }

            foreach(int count in charCount)
            {
                if(count!=0)
                    return false;
            }
            return true;
        }
        public static void main(string[] args)
        {
            string s = "anagram";
            string t = "nagaram";
            Console.WriteLine(IsAnagramDictionaryApproach(s, t));
            Console.WriteLine(IsAnagramArrayApproach(s, t));
        }
    }
}
