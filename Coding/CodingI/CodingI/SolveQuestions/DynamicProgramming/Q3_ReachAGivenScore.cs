namespace CodingI.SolveQuestions.DynamicProgramming
{
    public class Q3_ReachAGivenScore
    {
        /*
            Q - Count Ways with 3, 5 and 10
         
            Consider a game where a player can score 3 or 5 or 10 points in a move. Given a total score n, find number of distinct combinations to reach the given score.

            Examples:

            Input: n = 10
            Output: 2
            Explanation:
            There are two ways {5,5} and {10}.
            Input: n = 20
            Output: 4
            Explanation:
            There are four possible ways. {5,5,5,5}, {3,3,3,3,3,5}, {10,10}, {5,5,10}.
         */
        public static int ReachScore(int[] scores, int n, int idx)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n < 0 || idx == scores.Length)
            {
                return 0;
            }

            int takeScore = ReachScore(scores, n - scores[idx], idx);
            int skipScore = ReachScore(scores, n, idx + 1);

            return takeScore + skipScore;
        }
        public static void main()
        {
            int[] scores = [3, 5, 10];
            int n = 20;
            Console.WriteLine(ReachScore(scores, n, 0));
        }
    }
}
