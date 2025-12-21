using System.Text;

namespace CodingI.SolveQuestions.Strings
{
    internal class Q4RemoveConsecutiveCharacters
    {
        public static string RemoveConsecutiveCharacters(string s)
        {
            if (s.Length == 0)
                return "";
            var result = new StringBuilder();
            foreach(char c in s)
            {
                if (result.Length > 0 && result[result.Length - 1] == c)
                {
                    result.Remove(result.Length - 1, 1);
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        public static void main(string[] args)
        {
            Console.WriteLine(RemoveConsecutiveCharacters("abbaca"));
            Console.WriteLine(RemoveConsecutiveCharacters("azxxzy"));
        }
    }
}
