namespace CodingI.SolveQuestions.Strings
{
    internal class Q6ConvertSentenceToEquivalentMobileNumericKeypadSequence
    {
        // This code converts a sentence into its equivalent numeric sequence based on a mobile numeric keypad layout with Time Complexity O(n) where n is the length of the input string and Space Complexity O(1) since we are using a fixed-size array for the keypad mapping.
        public static string printSequence(string seq, string[] str)
        {
            string result = "";
            int n = str.Length;
            for(int i=0; i < seq.Length; i++)
            {
                // If the character is a space, we can add 0 to the result
                if (seq[i]==' ')
                {
                    result += 0;
                }
                else
                {
                    result += str[seq[i] - 'A'];
                }
            }
            return result;
        }
        public static void main(string[] args)
        {
            string seq = "HELLO WORLD";
            string[] str = ["2","22", "222", "3", "33", "333", "4", "44", "444", "5", "55", "555", "6", "66", "666", "7", "77", "777", "7777", "8", "88", "888", "9", "99", "999", "9999"];
            Console.WriteLine(printSequence(seq, str));
        }
    }
}
