namespace CodingI.SolveQuestions.Strings
{
    public class Q14_Count_Palindromic_Subsequences
    {
        // Naive approach to count all palindromic substrings in a given string
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

            public static int CountPalindromeSubStrings(string s)
            {
                int count = 0;
                int n = s.Length;
                for(int i = 0; i < n; i++)
                {
                    for(int j = i; j < n; j++)
                    {
                        string sub = s.Substring(i, j - i + 1);
                        if (isPalindrome(sub))
                        {
                            Console.WriteLine(sub);
                            count++;
                        }
                    }
                }
                return count;
            }
        }
        public static void main(string[] args)
        {
            string s = "ababa";
            int result = NaiveApproach.CountPalindromeSubStrings(s);
            Console.WriteLine(result);
        }
    }
}
