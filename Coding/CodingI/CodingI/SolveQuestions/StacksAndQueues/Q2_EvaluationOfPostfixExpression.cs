namespace CodingI.SolveQuestions.Stacks
{
    public class Q2_EvaluationOfPostfixExpression
    {
        public static int Operations(int a, int b , string exp)
        {
            switch (exp)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "^": return a * b;
                default: return 0;
            }
        }

        public static int CalculatePostfixExpression(string[] arr)
        {
            Stack<int> stack = new Stack<int>();
            int sol = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out int x))
                {
                    stack.Push(x);
                    continue;
                }
                int b = stack.Pop();
                int a = stack.Pop();

                sol = Operations(a, b, arr[i]);
                stack.Push(sol);
            }
            return sol;
        }

        public static void main()
        {
            string[] arr = ["2", "3", "1", "*", "+", "9", "-"];
            int result = CalculatePostfixExpression(arr);
            Console.WriteLine(result);
        }

    }
}
