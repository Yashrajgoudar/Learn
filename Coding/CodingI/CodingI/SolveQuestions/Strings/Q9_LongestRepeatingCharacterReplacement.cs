namespace CodingI.SolveQuestions.Strings
{
    internal class Q9_LongestRepeatingCharacterReplacement
    {
        // Naive approach to find the longest substring with at most k changes
        // Time Complexity: O(n^3), Space Complexity: O(1)
        public class LongestRepeatingCharacterNaiveApproach
        {
            // Function to get the maximum frequency of 
            // any character in the substring [l, r]
            static int GetMaxFreq(string s, int l, int r)
            {
                Dictionary<char, int> m = new Dictionary<char, int>();
                int res = 1;

                // Count the frequency of each character 
                // in the substring
                for (int i = l; i <= r; i++)
                {
                    if (!m.ContainsKey(s[i]))
                        m[s[i]] = 0;
                    m[s[i]]++;
                }

                // Find the maximum frequency of any character
                foreach (var entry in m)
                {
                    res = Math.Max(res, entry.Value);
                }

                return res;
            }

            // Function to find the maximum length of substring
            // with at most k changes
            public static int LongestSubstr(string s, int k)
            {
                int maxlen = 1;
                int n = s.Length;

                // Try every possible starting point of the substring
                for (int l = 0; l < n; l++)
                {
                    for (int r = l; r < n; r++)
                    {

                        // Get the maximum frequency of any 
                        // character in the substring [l, r]
                        int f = GetMaxFreq(s, l, r);

                        // If the number of changes required is <= k,
                        // update the maximum length
                        if (r - l + 1 - f <= k)      // (length of substring) - (count of the majority char) = (r - l + 1) - f
                            maxlen = Math.Max(maxlen, r - l + 1);
                    }
                }

                return maxlen;
            }
        }

        // Sliding window approach to find the longest substring with at most k changes
        // Time Complexity: O(n * 26), Space Complexity: O(1)
        public static int LongestRepeatingCharacterWindowSlidingApproach(string s, int k)
        {
            int res = 0, n = s.Length;

            // Try replacing other characters to form 
            // a string of each character 'A' to 'Z'
            for (char c = 'A'; c <= 'Z'; c++)
            {
                int l = 0, r = 0, cnt = 0;

                // Sliding window from l to r
                while (r < n)
                {
                    if (s[r] == c)
                    {
                        r++;
                    }
                    else if (cnt < k)
                    {
                        r++;
                        cnt++;
                    }
                    else if (s[l] == c)
                    {
                        l++;
                    }
                    else
                    {
                        l++;
                        cnt--;
                    }

                    // Update the maximum length of substring
                    res = Math.Max(res, r - l);
                }
            }
            return res;
        }

        // Sliding window approach using a hashmap to find the longest substring with at most k changes
        // Time Complexity: O(n), Space Complexity: O(1)
        public static int LongestRepeatingCharacterWindowSlidingHashMapApproach(string s, int k)
        {
            int n = s.Length;
            Dictionary<char, int> freq = new Dictionary<char, int>();
            int maxFreq = 0;
            int res = 0;

            int l = 0; // Left boundary of the window

            // Right boundary of the window
            for (int r = 0; r < n; r++)
            {
                // Increase the frequency of the 
                // current character
                if (!freq.ContainsKey(s[r]))
                    freq[s[r]] = 0;
                freq[s[r]]++;

                // Update maxFreq with the frequency of
                // the most frequent character in the
                // current window
                maxFreq = Math.Max(maxFreq, freq[s[r]]);

                // Shrink the window if more than k changes
                // required
                if (r - l + 1 - maxFreq > k)
                {
                    freq[s[l]]--;
                    l++;
                }

                // Update the maximum length of the substring
                res = Math.Max(res, r - l + 1);
            }

            return res;
        }
        public static void main(string[] args)
        {
            string s = "AABBBAAB";
            int k = 2;
            int result = LongestRepeatingCharacterNaiveApproach.LongestSubstr(s, k);
            Console.WriteLine("The length of the longest substring with at most " + k + " changes is: " + result);

            int resultSlidingWindow = LongestRepeatingCharacterWindowSlidingApproach(s, k);
            Console.WriteLine("The length of the longest substring with at most " + k + " changes using sliding window approach is: " + resultSlidingWindow);

            int resultSlidingWindowHashMap = LongestRepeatingCharacterWindowSlidingHashMapApproach(s, k);
            Console.WriteLine("The length of the longest substring with at most " + k + " changes using sliding window with hashmap approach is: " + resultSlidingWindowHashMap);
        }
    }
}
