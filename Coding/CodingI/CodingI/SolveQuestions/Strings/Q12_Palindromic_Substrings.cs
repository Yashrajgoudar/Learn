namespace CodingI.SolveQuestions.Strings
{
    internal class Q12_Palindromic_Substrings
    {
        // Expand Around Center approach to count all palindromic substrings in a given string
        // Time Complexity: O(n^2), where n is the length of the string
        // Space Complexity: O(1)
        public class ExpandAroundCenterApproach
        {
            public static int ExpandAround(string s, int left, int right)
            {
                int count = 0;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
                return count;
            }
            public static int LongestPalindromeSubstring(string s)
            {
                int total = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    total += ExpandAround(s, i, i);
                    total += ExpandAround(s, i, i + 1);
                }
                return total;
            }
        }

        // Manacher's Algorithm to count all palindromic substrings in a given string
        // Time Complexity: O(n), where n is the length of the string
        // Space Complexity: O(n)
        public class ManacherAlgorithmApproach
        {
            public static int CountSubstrings_Manacher(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;

                // Step 1: Transform the string
                // Example: "abba" -> "^#a#b#b#a#$"
                char[] t = new char[s.Length * 2 + 3];
                t[0] = '^';
                t[t.Length - 1] = '$';
                int idx = 1;
                foreach (char c in s)
                {
                    t[idx++] = '#';
                    t[idx++] = c;
                }
                t[idx] = '#';

                int[] p = new int[t.Length];
                int center = 0, right = 0;
                int count = 0;

                // Step 2: Iterate through transformed string
                for (int i = 1; i < t.Length - 1; i++)
                {
                    int mirror = 2 * center - i;

                    if (i < right)
                        p[i] = Math.Min(right - i, p[mirror]);

                    // Expand around center i
                    while (t[i + p[i] + 1] == t[i - p[i] - 1])
                        p[i]++;

                    // Update center and right boundary
                    if (i + p[i] > right)
                    {
                        center = i;
                        right = i + p[i];
                    }

                    // Each position contributes (p[i]+1)/2 palindromic substrings in original string
                    count += (p[i] + 1) / 2;
                }

                return count;
            }
        }
        public static void main(string[] args)
        {
            string s = "abc";
            Console.WriteLine(ExpandAroundCenterApproach.LongestPalindromeSubstring(s));
            Console.WriteLine(ManacherAlgorithmApproach.CountSubstrings_Manacher(s));
        }
    }
}
