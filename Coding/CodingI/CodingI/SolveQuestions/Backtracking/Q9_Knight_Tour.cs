namespace CodingI.SolveQuestions.Backtracking
{
    public class Q9_Knight_Tour
    {

        public static bool GenerateKnightTourConfig(List<List<int>> config, int expValue, int row, int col, int n)
        {
            if (row < 0 || col < 0 || row >= n || col >= n || config[row][col] != 0)
            {
                return false;
            }
            if(expValue== (n*n)-1)
            {
                return true;
            }
            config[row][col] = expValue;
            bool ans1 = GenerateKnightTourConfig(config, expValue + 1, row + 2, col + 1, n);
            bool ans2 = GenerateKnightTourConfig(config, expValue + 1, row + 1, col + 2, n);
            bool ans3 = GenerateKnightTourConfig(config, expValue + 1, row - 1, col + 2, n);
            bool ans4 = GenerateKnightTourConfig(config, expValue + 1, row - 2, col + 1, n);
            bool ans5 = GenerateKnightTourConfig(config, expValue + 1, row - 2, col - 1, n);
            bool ans6 = GenerateKnightTourConfig(config, expValue + 1, row - 1, col - 2, n);
            bool ans7 = GenerateKnightTourConfig(config, expValue + 1, row + 1, col - 2, n);
            bool ans8 = GenerateKnightTourConfig(config, expValue + 1, row + 2, col - 1, n);
            if(ans1 || ans2 || ans3 || ans4 || ans5 || ans6 || ans7 || ans8)
            {
                return true;
            }
            config[row][col] = 0;
            return false;
        }

        public static List<List<int>> FindKnightTourConfig(int n)
        {
            List<List<int>> config = new List<List<int>>(n);

            for (int i = 0; i < n; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < n; j++)
                    row.Add(0);

                config.Add(row);
            }
            GenerateKnightTourConfig(config, 0, 0, 0, n);
            return config;
        }
        public static void main()
        {
            List<List<int>> knightConfig = FindKnightTourConfig(5);

            foreach (List<int> n in knightConfig)
            {
                foreach (int n2 in n)
                {
                    Console.Write(n2+",");
                }
                Console.WriteLine();
            }
        }
    }
}
