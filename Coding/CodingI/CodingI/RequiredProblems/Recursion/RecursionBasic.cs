namespace CodingI.RequiredProblems.Recursion
{
    public class RecursionBasic
    {
        //Print Numbers in descending order using Recursion
        public void PrintNumbers(int n)
        {
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            Console.WriteLine(n);
            PrintNumbers(n - 1);
        }

        //Recusive Function to calculate Factorial
        public int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        //Recursive Function to calculate Sum of N numbers.
        public int SumOfNNumbers(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return n + SumOfNNumbers(n - 1);
        }
    }
}
