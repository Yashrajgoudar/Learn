namespace CodingI.SolveQuestions.Strings
{
    internal class Q3ValidParentheses
    {
        // This method checks if the given string has valid parentheses using a stack approach with Time Complexity O(n) and Space Complexity O(n).
        // Non Stack Approach is not possible in C# because strings are immutable
        public static bool isValidParenthesesStackApproach(string s)
        {
            Stack<char> chars = new Stack<char>();
            foreach(char c in s)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    chars.Push(c);
                }
                else
                {
                    if (chars.Count == 0)
                        return false;
                    char top = chars.Pop();
                    if((c=='}' && top !='{') || (c==']' && top != '[') || (c == ')' && top != '('))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void main(string[] args)
        {
            string s = "{[()]}";
            Console.WriteLine(isValidParenthesesStackApproach(s));
        }
    }
}
