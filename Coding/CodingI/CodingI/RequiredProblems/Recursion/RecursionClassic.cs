using System.Collections.Generic;

namespace CodingI.RequiredProblems.Recursion
{
    public class RecursionClassic
    {
        //Recursion Method to print the Fibonacci Series -> 0, 1, 1, 2, 3, 5, 8, 13.....
        public int FibonacciSeries(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }

        //Recursion Method to check if an array is sorted or not.
        public bool CheckSorted(int[] arr, int n)
        {
            if (n == 0 || n == 1)
                return true;
            return arr[n - 1] >= arr[n - 2] && CheckSorted(arr, n - 1);
        }

        //Recursion Method to print Subsets of an array
        public void printSubsets(int[] arr, List<int> ans, int i)
        {
            if (i == arr.Length)
            {
                Console.WriteLine(string.Join(", ", ans));
                return;
            }

            ans.Add(arr[i]);    //Include the element in the new array
            printSubsets(arr, ans, i + 1);     //Call the same method with included data
            ans.Remove(arr[i]);     //Remove the added value in the new array.
            printSubsets(arr, ans, i + 1);    //Call the same method with excluded data
        }

        //This is similar to the above method instead of printing the subsets we are returning them in this method.
        public void getAllSubsets(int[] nums, List<int> ans, int i, IList<IList<int>> allSubsets)
        {
            if (i == nums.Length)
            {
                allSubsets.Add(new List<int>(ans));
                return;
            }
            ans.Add(nums[i]);
            getAllSubsets(nums, ans, i + 1, allSubsets);
            ans.Remove(nums[i]);
            getAllSubsets(nums, ans, i + 1, allSubsets);
        }

        //Recursion method to print Subsets of an array when the array contains duplicates.
        public void getAllSubsetsSameValue(int[] nums, List<int> ans, int i, IList<IList<int>> allSubsets)
        {
            if (i == nums.Length)
            {
                allSubsets.Add(new List<int>(ans));
                return;
            }
            ans.Add(nums[i]);
            getAllSubsetsSameValue(nums, ans, i + 1, allSubsets);
            ans.Remove(nums[i]);
            int index = i + 1;
            while (index < nums.Length && nums[index] == nums[index - 1])
                index++;
            getAllSubsetsSameValue(nums, ans, index, allSubsets);
        }

        //Recusion method to get all the Permutations of elements in an array.
        public void getPermutations(int[] nums, int idx, IList<IList<int>> allSubsets)
        {
            if (idx == nums.Length)
            {
                allSubsets.Add(new List<int>(nums));
                return;
            }

            for (int i = idx; i < nums.Length; i++)
            {
                (nums[idx], nums[i]) = (nums[i], nums[idx]);
                getPermutations(nums, idx + 1, allSubsets);
                (nums[i], nums[idx]) = (nums[idx], nums[i]);
            }
        }


        public class NQueens()
        {
            public bool isSafe(char[][] board, int row, int col, int n)
            {
                for (int i = 0; i < row; i++)
                {
                    if (board[i][col] == 'Q')
                        return false;
                }

                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                    if (board[i][j] == 'Q')
                        return false;

                for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                    if (board[i][j] == 'Q')
                        return false;
                return true;
            }

            public void GetNQueens(char[][] board, int row, int n, IList<IList<string>> ans)
            {
                if (row == n)
                {
                    var solution = new List<string>();
                    foreach (var r in board)
                        solution.Add(new string(r));
                    ans.Add(solution);
                    return;
                }
                for (int col = 0; col < n; col++)
                {
                    if (isSafe(board, row, col, n))
                    {
                        board[row][col] = 'Q';
                        GetNQueens(board, row + 1, n, ans);
                        board[row][col] = '.';
                    }
                }
            }

            public IList<IList<string>> SolveNQueens(int n)
            {
                char[][] board = new char[n][];
                IList<IList<string>> ans = new List<IList<string>>();
                for (int i = 0; i < n; i++)
                {
                    board[i] = new string('.', n).ToCharArray();
                }
                GetNQueens(board, 0, n, ans);
                return ans;
            }
        }


        public class SudokuSolver()
        {
            public bool isSafe(char[][] board, int row, int col, int dig)
            {
                int start_row = row / 3 * 3;
                int start_col = col / 3 * 3;

                for (int j = 0; j < 9; j++)
                {
                    if (board[row][j] == dig)
                    {
                        return false;
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    if (board[i][col] == dig)
                    {
                        return false;
                    }
                }

                for (int i = start_row; i <= start_row + 2; i++)
                {
                    for (int j = start_col; j <= start_col + 2; j++)
                    {
                        if (board[i][j] == dig)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            public bool SolveSudoku(char[][] board, int row, int col)
            {
                if (row == 9)
                {
                    return true;
                }

                int nextRow = row, nextCol = col + 1;
                if (nextCol == 9)
                {
                    nextRow = row + 1;
                    nextCol = 0;
                }

                if (board[row][col] != '.')
                {
                    return SolveSudoku(board, nextRow, nextCol);
                }

                for (char dig = '1'; dig <= '9'; dig++)
                {
                    if (isSafe(board, row, col, dig))
                    {
                        board[row][col] = dig;
                        if (SolveSudoku(board, nextRow, nextCol))
                            return true;
                        board[row][col] = '.';
                    }
                }

                return false;
            }
        }


        public class RatInMaze()
        {
            public void PathFinder(List<List<int>> mat, int row, int col, string path, List<string> ans, List<List<bool>> vis)
            {
                int n = mat.Count;

                if(row<0 || col<0 || row>=n || col>=n || mat[row][col] == 0 || vis[row][col] == true)
                {
                    return;
                }

                if(row==n-1 && col == n - 1)
                {
                    ans.Add(path);
                    return;
                }

                vis[row][col] = true;

                PathFinder(mat, row + 1, col, path + "D", ans, vis);
                PathFinder(mat, row - 1, col, path + "U", ans, vis);
                PathFinder(mat, row, col - 1, path + "L", ans, vis);
                PathFinder(mat, row, col + 1, path + "R", ans, vis);

                vis[row][col] = false;
            }

            public List<string> FindPath(List<List<int>> mat)
            {
                int n = mat.Count;
                List<string> ans = new List<string>();
                string path = "";

                List<List<bool>> vis = Enumerable.Range(0, n)
                    .Select(_ => Enumerable.Repeat(false, n).ToList())
                    .ToList();
                PathFinder(mat, 0, 0, path, ans, vis);
                return ans;
            }
        }


        public class CombinationSum()
        {
            private HashSet<string> uniqueCombSet = new HashSet<string>();

            //Brute Force Approach -> Use only to understand the recusion flow
            private void FindCombinationSum(int[] arr, IList<IList<int>> ans, IList<int> comb, int i, int tar)
            {
                if(i == arr.Length || tar < 0)
                {
                    return;
                }

                if(tar == 0)
                {
                    string key = string.Join(",", comb);
                    if (!uniqueCombSet.Contains(key))
                    {
                        ans.Add(new List<int>(comb));
                        uniqueCombSet.Add(key);
                    }
                    return;
                }

                comb.Add(arr[i]);
                FindCombinationSum(arr, ans, comb, i + 1, tar - arr[i]);    //Single Inclusion Call
                FindCombinationSum(arr, ans, comb, i, tar - arr[i]);    //Multiple Inclusion Call

                comb.RemoveAt(comb.Count - 1);  //Remove the included element while backtracking.
                FindCombinationSum(arr, ans, comb, i + 1, tar);    //Exclusion Call
            }

            private void FindCombinationSumOptimized(int[] arr, IList<IList<int>> ans, IList<int> comb, int start, int tar)
            {
                if(tar == 0)
                {
                    ans.Add(new List<int>(comb));
                    return;
                }

                for(int i = start; i < arr.Length; i++)
                {
                    if (arr[i] > tar)
                    {
                        break;
                    }
                    comb.Add(arr[i]);
                    FindCombinationSumOptimized(arr, ans, comb, i, tar - arr[i]);    //Single Inclusion Call
                    comb.RemoveAt(comb.Count - 1);  //Remove the included element while backtracking.
                }
            }

            public IList<IList<int>> FindCombSum(int[] arr, int tar)
            {
                IList<IList<int>> ans = new List<IList<int>>();

                //FindCombinationSum(arr, ans, [], 0, tar);
                FindCombinationSumOptimized(arr, ans, [], 0, tar);
                return ans;
            }
        }


        public class PalindromePartioning()
        {
            private bool isPalindrome(string s)
            {
                //Check if the string is palindrome or not.
                int i = 0, j = s.Length - 1;
                while (i < j)
                {
                    if (s[i] != s[j])
                        return false;
                    i++;
                    j--;
                }
                return true;
            }

            private void FindPalindromeParts(string s, IList<IList<string>> ans,  IList<string> partition)
            {
                //Base case for recursion
                if (s.Length == 0)
                {
                    ans.Add(new List<string>(partition));
                    return;
                }
                //Iterate through the string and check if the substring is palindrome or not.
                for (int i=0; i < s.Length; i++)
                {
                    string subStr = s.Substring(0, i + 1);
                    //Check if the substring is palindrome or not.
                    if (isPalindrome(subStr))
                    {
                        //If it is palindrome then add it to the partition.
                        partition.Add(subStr);
                        //Call the same method with the remaining string.
                        FindPalindromeParts(s.Substring(i + 1), ans, partition);
                        //Remove the last added substring from the partition.
                        partition.RemoveAt(partition.Count - 1);
                    }
                }
            }
            public IList<IList<string>> PalindromePartition(string s)
            {
                IList<IList<string>> ans = new List<IList<string>>();
                IList<string> partition = new List<string>();
                FindPalindromeParts(s, ans, partition);
                return ans;
            }
        }


        public class CountInversions()
        {
            //Brute Force Approach -> O(n^2)
            public int BruteForceApproach(int[] arr)
            {
                int count = 0;
                for(int i = 0; i < arr.Length; i++)
                {
                    for(int j = i+1; j < arr.Length; j++)
                    {
                        if(arr[i] > arr[j])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }

            public class OptimizedCountInversion()
            {
                //Optimized Approach -> O(nlogn)
                public int Merge(int[] arr, int start, int end, int mid)
                {
                    List<int> temp = [];

                    int i = start, j = mid + 1;
                    int invCount = 0;
                    while (i <= mid && j <= end)
                    {
                        if (arr[i] <= arr[j])
                        {
                            temp.Add(arr[i]);
                            i++;
                        }
                        else
                        {
                            temp.Add(arr[j]);
                            j++;
                            invCount += (mid - i + 1); // Count the inversions
                        }
                    }

                    while (i <= mid)
                    {
                        temp.Add(arr[i]);
                        i++;
                    }

                    while (j <= end)
                    {
                        temp.Add(arr[j]);
                        j++;
                    }

                    for (int idx = 0; idx < temp.Count; idx++)
                    {
                        arr[start + idx] = temp[idx];
                    }

                    return invCount;
                }
                public int Divide(int[] arr, int start, int end)
                {
                    if (start < end)
                    {
                        int mid = start + (end - start) / 2;
                        int leftInvCount = Divide(arr, start, mid);
                        int rightInvCount = Divide(arr, mid + 1, end);
                        int invCount = Merge(arr, start, end, mid);
                        return leftInvCount + rightInvCount + invCount;
                    }
                    return 0;
                }
            }

            public int CountInversion(int[] arr)
            {
                //Optimized Approach
                var optimizedCountInversion = new OptimizedCountInversion();
                return optimizedCountInversion.Divide(arr, 0, arr.Length - 1);


                //return BruteForceApproach(arr);
            }
        }

        public bool checkValidGridKnightsTour(int[][] grid,int row,int col, int n, int expVal)
        {
            if(row<0 || col<0 ||row>=n || col>=n || grid[row][col] != expVal)
            {
                return false;
            }

            if (expVal == n * n - 1)
            {
                return true;
            }

            bool ans1 = checkValidGridKnightsTour(grid, row - 2, col + 1, n, expVal + 1);
            bool ans2 = checkValidGridKnightsTour(grid, row - 1, col + 2, n, expVal + 1);
            bool ans3 = checkValidGridKnightsTour(grid, row + 1, col + 2, n, expVal + 1);
            bool ans5 = checkValidGridKnightsTour(grid, row + 2, col + 1, n, expVal + 1);
            bool ans4 = checkValidGridKnightsTour(grid, row + 2, col - 1, n, expVal + 1);
            bool ans6 = checkValidGridKnightsTour(grid, row + 1, col - 2, n, expVal + 1);
            bool ans7 = checkValidGridKnightsTour(grid, row - 1, col - 2, n, expVal + 1);
            bool ans8 = checkValidGridKnightsTour(grid, row - 2, col - 1, n, expVal + 1);

            return ans1 || ans2 || ans3 || ans4 || ans5 || ans6 || ans7 || ans8;
        }
    }
}
