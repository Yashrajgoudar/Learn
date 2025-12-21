namespace CodingI.SolveQuestions.Strings
{
    internal class Q8LongestSubstringWithoutRepeatingCharacters
    {
        //Naive Approach with Time Complexity O(26*N) and Space Complexity O(1)
        public static int LengthOfLongestSubstringNaive(string s)
        {
            int n = s.Length;
            int maxLength = 0;
            for(int i = 0; i < n; i++)
            {
                bool[] isVisited = new bool[26];
                for(int j = i; j < n; j++)
                {
                    if (isVisited[s[j]-'a'])
                    {
                        break;
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, j - i + 1);
                        isVisited[s[j] - 'a'] = true;
                    }
                }
            }
            return maxLength;
        }

        //Sliding Window Approach with Time Complexity O(N) and Space Complexity O(1)
        public static int LengthOfLongestSubstringSliding(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s.Length;
            int maxLength = 0;
            int left = 0, right = 0;
            bool[] isVisited = new bool[26];
            while (right < s.Length)
            {
                while (isVisited[s[right] - 'a'])
                {
                    isVisited[s[left] - 'a'] = false;
                    left++;
                }
                isVisited[s[right] - 'a'] = true;
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            return maxLength;
        }

        // Last Index Approach with Time Complexity O(N) and Space Complexity O(1)
        public static int LengthOfLongestSubstringLastIndex(string s)
        {
            int n = s.Length;
            int res = 0;

            // last index of all characters is initialized as -1
            int[] lastIndex = new int[26];
            for (int i = 0; i < 26; i++)
            {
                lastIndex[i] = -1;
            }

            // Initialize start of current window
            int start = 0;

            // Move end of current window
            for (int end = 0; end < n; end++)
            {


                start = Math.Max(start, lastIndex[s[end] - 'a'] + 1);

                // Update result if we get a larger window
                res = Math.Max(res, end - start + 1);

                // Update last index of s[end]
                lastIndex[s[end] - 'a'] = end;
            }
            return res;
        }

        //Sliding Window Approach for all characters with Time Complexity O(N) and Space Complexity O(1)
        public static int LengthOfLongestSubstringSlidingAllCharacters(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s.Length;
            int maxLength = 0;
            int left = 0, right = 0;
            bool[] isVisited = new bool[256];
            while (right < s.Length)
            {
                while (isVisited[s[right]])
                {
                    isVisited[s[left]] = false;
                    left++;
                }
                isVisited[s[right]] = true;
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            return maxLength;
        }
        public static void main(string[] args)
        {
            string s = "geeksforgeeks";
            Console.WriteLine(LengthOfLongestSubstringNaive(s));
            Console.WriteLine(LengthOfLongestSubstringSliding(s));
            Console.WriteLine(LengthOfLongestSubstringLastIndex(s));
        }
    }
}
