using CodingI.RequiredProblems.Array;
using CodingI.RequiredProblems.Recursion;
namespace HelloWorld
{
    class Program
    {
        public readonly ArraySearch _search;
        public readonly ArraySorting _sort;
        public readonly RecursionBasic _recursionBasic;
        public readonly RecursionClassic _recursionClassic;
        public Program()
        {
            _search = new ArraySearch();
            _sort = new ArraySorting();
            _recursionBasic = new RecursionBasic();
            _recursionClassic = new RecursionClassic();
        }

        public int SearchOperation(string searchName)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int key = 7;
            switch (searchName)
            {
                case "Linear":
                    return _search.LinearSearch(arr, key);
                case "Binary":
                    return _search.BinarySearch(arr, key);
                case "RecursiveBinary":
                    return _search.RecursiveBinarySearch(arr, key, 0, arr.Length - 1);
                default:
                    return 0;
            }
        }

        public int[] SortOperation(string sortName)
        {
            //int[] arr = { 64, 25, 12, 22, 11 };
            int[] arr = { 4, 2, 2, 8, 3, 3, 1 };
            switch (sortName)
            {
                case "Selection":
                    return _sort.SelectionSort(arr);
                case "Bubble":
                    return _sort.BubbleSort(arr);
                case "Insertion":
                    return _sort.InsertionSort(arr);
                case "MergeSort":
                    var mergeSort = new ArraySorting.MergeSorting();
                    return mergeSort.MergeSort(arr);
                case "QuickSort":
                    var quickSort = new ArraySorting.QuickSorting();
                    return quickSort.QuickSort(arr);
                case "Counting":
                    return _sort.CountingSorting(arr);
                default:
                    return [];
            }
        }

        public void CallRecursion(string recusionName)
        {
            switch (recusionName)
            {
                case "PrintNumbers":
                    _recursionBasic.PrintNumbers(10);
                    break;

                case "Factorial":
                    int result = _recursionBasic.Factorial(4);
                    Console.WriteLine(result);
                    break;

                case "SumOfNNumbers":
                    int sumNumbers = _recursionBasic.SumOfNNumbers(4);
                    Console.WriteLine(sumNumbers);
                    break;

                case "FibonacciSeries":
                    for (int i = 0; i < 8; i++)
                    {
                        Console.WriteLine(_recursionClassic.FibonacciSeries(i));
                    }
                    break;
                
                case "CheckSorted":
                    int[] arr = { 11, 12, 45, 67, 89, 90 };
                    bool isSorted = _recursionClassic.CheckSorted(arr, arr.Length);
                    Console.WriteLine(isSorted);
                    break;

                case "PrintSubsets":
                    int[] subSetArray = { 1, 2, 3 };
                    _recursionClassic.printSubsets(subSetArray, [], 0);
                    break;

                case "GetSubsets":
                    int[] getSubSetArray = { 1, 2, 3 };
                    IList<IList<int>> allSubsets = [];
                    _recursionClassic.getAllSubsets(getSubSetArray, [], 0, allSubsets);
                    foreach (var subset in allSubsets)
                    {
                        Console.WriteLine("[" + string.Join(", ", subset) + "]");
                    }
                    break;

                case "GetSubsetsSameValue":
                    int[] getSubSetArraySameValue = { 2, 1, 2 };
                    Array.Sort(getSubSetArraySameValue);
                    IList<IList<int>> allSubsetsSameValue = [];
                    _recursionClassic.getAllSubsetsSameValue(getSubSetArraySameValue, [], 0, allSubsetsSameValue);
                    foreach (var subset in allSubsetsSameValue)
                    {
                        Console.WriteLine("[" + string.Join(", ", subset) + "]");
                    }
                    break;

                case "GetPemutations":
                    int[] getPermuteArrayValue = { 1, 2, 3 };
                    IList<IList<int>> allSubsetsPermute = [];
                    _recursionClassic.getPermutations(getPermuteArrayValue, 0, allSubsetsPermute);
                    foreach (var subset in allSubsetsPermute)
                    {
                        Console.WriteLine("[" + string.Join(", ", subset) + "]");
                    }
                    break;

                case "NQueens":
                    int n = 4;
                    IList<IList<string>> allValidNQueens = [];
                    var nQueens = new RecursionClassic.NQueens();
                    var nQueensResult = nQueens.SolveNQueens(n);
                    foreach (var subset in nQueensResult)
                    {
                        Console.WriteLine("[" + string.Join(", ", subset) + "]");
                    }
                    break;

                case "SudukoSolver":
                    char[][] board =
                                    [
                                        ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
                                        ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                                        ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                                        ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                                        ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                                        ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                                        ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                                        ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                                        ['.', '.', '.', '.', '8', '.', '.', '7', '9']
                                    ];

                    var sudukoSolver = new RecursionClassic.SudokuSolver();
                    sudukoSolver.SolveSudoku(board,0,0);
                    foreach (var subset in board)
                    {
                        Console.WriteLine("[" + string.Join(", ", subset) + "]");
                    }
                    break;

                case "RateInMaze":
                    List<List<int>> mat = [[1, 0, 0, 0], [1, 1, 0, 1], [1, 1, 0, 0], [0, 1, 1, 1]];
                    var mazeSolver = new RecursionClassic.RatInMaze();
                    var mazeResult = mazeSolver.FindPath(mat);
                    foreach (var maze in mazeResult)
                    {
                        Console.WriteLine(maze);
                    }
                    break;

                case "CombinationSum":
                    int[] combArr = [2, 3, 5];
                    int target = 8;
                    var combSum = new RecursionClassic.CombinationSum();
                    var combSumResult = combSum.FindCombSum(combArr,target);
                    foreach (var sumResult in combSumResult)
                    {
                        Console.WriteLine("[" + string.Join(", ", sumResult) + "]");
                    }
                    break;

                case "PalindromePartioning":
                    string str = "aab";
                    var palindromePartioning = new RecursionClassic.PalindromePartioning();
                    var palindromeResult = palindromePartioning.PalindromePartition(str);
                    foreach (var part in palindromeResult)
                    {
                        Console.WriteLine("[" + string.Join(", ", part) + "]");
                    }
                    break;

                case "CountInversions":
                    int[] inversionArray = { 1, 3, 5, 10, 2, 6, 8, 9 };
                    var countInversion = new RecursionClassic.CountInversions();
                    int count = countInversion.CountInversion(inversionArray);
                    Console.WriteLine(count);
                    break;

                case "KnightsTour":
                    //int[][] grid = [[0, 11, 16, 5, 20], [17, 4, 19, 10, 15], [12, 1, 8, 21, 6], [3, 18, 23, 14, 9], [24, 13, 2, 7, 22]];
                    int[][] grid = [[0, 3, 6], [5, 8, 1], [2, 7, 4]];
                    bool knightTourResult = _recursionClassic.checkValidGridKnightsTour(grid, 0, 0, grid.Length,0);
                    Console.WriteLine(knightTourResult);
                    break;


                default:
                    break;
            }
            return;
        }

        public static void main(string[] args)
        {
            Program program = new Program();

            //int search = program.SearchOperation("Linear");
            //Console.WriteLine(search);

            //int[] sort = program.SortOperation("Counting");
            //Console.WriteLine("Sorted Array: " + string.Join(", ", sort));

            program.CallRecursion("FibonacciSeries");
        }
    }
}