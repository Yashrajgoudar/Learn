using System;
using System.Collections.Generic;

namespace CodingI.SolveQuestions.Backtracking
{
    public class Q3_CrosswordPuzzle
    {
        /*
         Time Complexity: O((N*M) * 2^W)
         Space Complexity: O(W + N*M)
        */

        public static void SolveCrossWord(char[][] board,
                                          string[] words,
                                          int idx,
                                          List<char[][]> ans)
        {
            // ✅ Base Case: All words placed successfully
            if (idx == words.Length)
            {
                ans.Add(CloneBoard(board)); // Deep copy required
                return;
            }

            string word = words[idx];

            // Try placing current word in every cell
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    // Only attempt placement if first character matches or empty
                    if (board[i][j] == '-' || board[i][j] == word[0])
                    {
                        // ---- Try Horizontal Placement ----
                        if (CanPlaceHorizontally(board, word, i, j))
                        {
                            bool[] placed = PlaceHorizontally(board, word, i, j);

                            SolveCrossWord(board, words, idx + 1, ans);

                            // Backtrack
                            UnPlaceHorizontally(board, placed, i, j);
                        }

                        // ---- Try Vertical Placement ----
                        if (CanPlaceVertically(board, word, i, j))
                        {
                            bool[] placed = PlaceVertically(board, word, i, j);

                            SolveCrossWord(board, words, idx + 1, ans);

                            // Backtrack
                            UnPlaceVertically(board, placed, i, j);
                        }
                    }
                }
            }
        }

        // ------------------ HORIZONTAL ------------------

        private static bool CanPlaceHorizontally(char[][] board,
                                                 string word,
                                                 int row,
                                                 int col)
        {
            // Left boundary must be '+' or edge
            if (col > 0 && board[row][col - 1] != '+')
                return false;

            // Right boundary must be '+' or edge
            if (col + word.Length < board[row].Length &&
                board[row][col + word.Length] != '+')
                return false;

            for (int k = 0; k < word.Length; k++)
            {
                if (col + k >= board[row].Length)
                    return false;

                if (board[row][col + k] != '-' &&
                    board[row][col + k] != word[k])
                    return false;
            }

            return true;
        }

        private static bool[] PlaceHorizontally(char[][] board,
                                                string word,
                                                int row,
                                                int col)
        {
            bool[] placed = new bool[word.Length];

            for (int k = 0; k < word.Length; k++)
            {
                if (board[row][col + k] == '-')
                {
                    board[row][col + k] = word[k];
                    placed[k] = true;
                }
            }

            return placed;
        }

        private static void UnPlaceHorizontally(char[][] board,
                                                bool[] placed,
                                                int row,
                                                int col)
        {
            for (int k = 0; k < placed.Length; k++)
            {
                if (placed[k])
                    board[row][col + k] = '-';
            }
        }

        // ------------------ VERTICAL ------------------

        private static bool CanPlaceVertically(char[][] board,
                                               string word,
                                               int row,
                                               int col)
        {
            // Top boundary must be '+' or edge
            if (row > 0 && board[row - 1][col] != '+')
                return false;

            // Bottom boundary must be '+' or edge
            if (row + word.Length < board.Length &&
                board[row + word.Length][col] != '+')
                return false;

            for (int k = 0; k < word.Length; k++)
            {
                if (row + k >= board.Length)
                    return false;

                if (board[row + k][col] != '-' &&
                    board[row + k][col] != word[k])
                    return false;
            }

            return true;
        }

        private static bool[] PlaceVertically(char[][] board,
                                              string word,
                                              int row,
                                              int col)
        {
            bool[] placed = new bool[word.Length];

            for (int k = 0; k < word.Length; k++)
            {
                if (board[row + k][col] == '-')
                {
                    board[row + k][col] = word[k];
                    placed[k] = true;
                }
            }

            return placed;
        }

        private static void UnPlaceVertically(char[][] board,
                                              bool[] placed,
                                              int row,
                                              int col)
        {
            for (int k = 0; k < placed.Length; k++)
            {
                if (placed[k])
                    board[row + k][col] = '-';
            }
        }

        // ------------------ DEEP COPY ------------------

        private static char[][] CloneBoard(char[][] board)
        {
            char[][] copy = new char[board.Length][];

            for (int i = 0; i < board.Length; i++)
                copy[i] = (char[])board[i].Clone();

            return copy;
        }

        // ------------------ PRINT ------------------

        private static void PrintBoard(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                    Console.Write(board[i][j] + " ");

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // ------------------ MAIN ------------------

        public static void main()
        {
            char[][] crossword =
            {
                new char[] {'+','-','+'},
                new char[] {'-','-','-'},
                new char[] {'+','-','+'}
            };

            string[] words = { "and", "ant" };

            List<char[][]> ans = new List<char[][]>();

            SolveCrossWord(crossword, words, 0, ans);

            foreach (var solution in ans)
            {
                PrintBoard(solution);
            }
        }
    }
}