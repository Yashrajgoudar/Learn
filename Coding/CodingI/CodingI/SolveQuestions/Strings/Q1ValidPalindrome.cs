namespace CodingI.SolveQuestions.Strings
{
    public class Q1ValidPalindrome
    {
        // Find if a String is Palidrome with Time Complexity O(n)
        public static bool isPalindrome(string s)
        {
            if(s==null || s.Length == 0)
                return false;
            int left=0, right = s.Length - 1;
            while (left < right)
            {
                while(left<right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while(left<right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }
        public static void main(string[] args)
        {
            string s = "A man, a plan, a canal: Panamar";
            Console.WriteLine(isPalindrome(s)); // Output: True
        }
    }
}
