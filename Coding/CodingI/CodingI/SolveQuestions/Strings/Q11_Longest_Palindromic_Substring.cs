namespace CodingI.SolveQuestions.Strings
{
    internal class Q11_Longest_Palindromic_Substring
    {
        // Naive approach to find the longest palindromic substring in a given string
        // Time Complexity: O(n^3), where n is the length of the string
        // Space Complexity: O(1)
        public class NaiveApproach
        {
            public static bool isPalindrome(string s)
            {
                int left = 0;
                int right = s.Length - 1;
                while (left < right)
                {
                    if (s[left] != s[right])
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
                return true;
            }
            public static string LongestPalindromeSubstring(string s)
            {
                string long_str = "";
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        string sub = s.Substring(i, j - i + 1);
                        if (isPalindrome(sub) && sub.Length>long_str.Length)
                        {
                            long_str = sub;
                        }
                    }
                }
                return long_str;
            }
        }

        // Expand Around Center approach to find the longest palindromic substring in a given string
        // Time Complexity: O(n^2), where n is the length of the string
        // Space Complexity: O(1)
        public class ExpandAroundCenterApproach
        {
            public static string ExpandAround(string s,int left,int right)
            {
                while (left >= 0 && right<s.Length && s[left] == s[right])
                {
                    left--;
                    right++;
                }
                return s.Substring(left + 1, right - left - 1);
            }
            public static string LongestPalindromeSubstring(string s)
            {
                string long_str = "";
                for (int i = 0; i < s.Length; i++)
                {
                    string odd = ExpandAround(s, i, i);
                    string even = ExpandAround(s, i, i + 1);
                    string curr = odd.Length > even.Length ? odd : even;
                    if (curr.Length > long_str.Length)
                    {
                        long_str = curr;
                    }
                }
                return long_str;
            }
        }

        // Manacher's Algorithm to find the longest palindromic substring in a given string
        // Time Complexity: O(n), where n is the length of the string
        // Space Complexity: O(n), where n is the length of the string
        public class ManacherAlgorithmApproach
        {
            public static string LongestPalindromeSubstring(string s)
            {
                if (string.IsNullOrEmpty(s)) return "";

                // Step 1: Transform the string to avoid even/odd length distinction
                // Add '#' between characters and '^' at start and '$' at end
                // Example: "abba" -> "^#a#b#b#a#$"
                char[] t = new char[s.Length * 2 + 3];
                t[0] = '^';
                t[t.Length - 1] = '$';
                int index = 1;
                foreach (char c in s)
                {
                    t[index++] = '#';
                    t[index++] = c;
                }
                t[index] = '#';

                int[] p = new int[t.Length]; // palindrome radius array
                int center = 0, right = 0;   // current center and right boundary
                int maxLen = 0, centerIndex = 0;

                // Step 2: Compute p[i] for each position in transformed string
                for (int i = 1; i < t.Length - 1; i++)
                {
                    int mirror = 2 * center - i; // mirror of i around current center

                    if (i < right)
                        p[i] = Math.Min(right - i, p[mirror]);

                    // Expand around i
                    while (t[i + (p[i] + 1)] == t[i - (p[i] + 1)])
                        p[i]++;

                    // Update center and right boundary
                    if (i + p[i] > right)
                    {
                        center = i;
                        right = i + p[i];
                    }

                    // Track maximum length
                    if (p[i] > maxLen)
                    {
                        maxLen = p[i];
                        centerIndex = i;
                    }
                }

                // Step 3: Extract longest palindrome from original string
                int start = (centerIndex - maxLen) / 2;
                return s.Substring(start, maxLen);
            }
        }
        public static void main(string[] args)
        {
            string s = "babdabvsdfsf";
            Console.WriteLine(NaiveApproach.LongestPalindromeSubstring(s));
            Console.WriteLine(ExpandAroundCenterApproach.LongestPalindromeSubstring(s));
            Console.WriteLine(ManacherAlgorithmApproach.LongestPalindromeSubstring(s));
        }
    }
}
