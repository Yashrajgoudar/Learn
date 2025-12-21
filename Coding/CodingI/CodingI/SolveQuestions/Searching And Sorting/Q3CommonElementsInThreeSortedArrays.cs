namespace CodingI.SolveQuestions.Searching_And_Sorting
{
    internal class Q3CommonElementsInThreeSortedArrays
    {
        // This code finds common elements in three sorted arrays using a naive approach.
        // Time Complexity is O(n1 + n2 + n3) where n1, n2, and n3 are the lengths of the three arrays and Space Complexity is O(k) where k is the number of common elements found.
        public static List<int> FindCommonElementsNaive(int[] arr1, int[] arr2, int[] arr3)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach(int i in arr1)
            {
                map[i] = 1;
            }
            foreach(int i in arr2)
            {
                if(map.ContainsKey(i) && map[i] == 1)
                {
                    map[i] = 2;
                }
            }
            foreach (int i in arr3)
            {
                if (map.ContainsKey(i) && map[i] == 2)
                {
                    map[i] = 3;
                }
            }
            List<int> result = new List<int>();
            foreach (var kvp in map)
            {
                if (kvp.Value == 3)
                {
                    result.Add(kvp.Key);
                }
            }
            return result;
        }

        public static List<int> FindCommonElementsThreePointers(int[] arr1, int[] arr2, int[] arr3)
        {
            int i = 0, j = 0, k = 0;
            List<int> result = new List<int>();
            while(i<arr1.Length&&j < arr2.Length && k < arr3.Length)
            {
                if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
                {
                    result.Add(arr1[i]);
                    i++;
                    j++;
                    k++;
                    // To avoid duplicates, we can skip the same elements in all three arrays
                    while (i < arr1.Length && arr1[i] == arr1[i - 1]) i++;
                    while (j < arr2.Length && arr2[j] == arr2[j - 1]) j++;
                    while (k < arr3.Length && arr3[k] == arr3[k - 1]) k++;
                }
                else if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else if (arr2[j] < arr3[k])
                {
                    j++;
                }
                else
                {
                    k++;
                }
            }
            return result;
        }
        public static void main(string[] args)
        {
            int[] arr1 = { 1, 5, 10, 20, 20, 40, 80 };
            int[] arr2 = { 6, 7, 20, 20, 80, 100 };
            int[] arr3 = { 3, 4, 15, 20, 20, 30, 70, 80, 120 };
            List<int> commonElements = FindCommonElementsNaive(arr1, arr2, arr3);
            Console.WriteLine("Common elements in three sorted arrays: " + string.Join(", ", commonElements));
            List<int> commonElementsThreePointers = FindCommonElementsThreePointers(arr1, arr2, arr3);
            Console.WriteLine("Common elements in three sorted arrays using three pointers: " + string.Join(", ", commonElementsThreePointers));
        }
    }
}
