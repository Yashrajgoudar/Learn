namespace CodingI.SolveQuestions.Arrays
{
    public class Q6_SearchInRotatedSortedArray
    {
        public static class SearchInRotatedSortedArrayUsingTwoBinarySearch
        {
            public static int BinarySearch(int[] arr, int ele, int lo,int hi)
            {
                while (lo <= hi)
                {
                    int mid = lo + (hi - lo) / 2;
                    if (arr[mid] == ele)
                    {
                        return mid;
                    }
                    if (arr[mid] < ele)
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }
                return -1;
            }


            //Find Pivot(Index of smallest element)
            public static int FindPivot(int[] arr, int lo, int hi)
            {
                while (lo <= hi)
                {
                    if (arr[lo] <= arr[hi])
                    {
                        return lo;
                    }

                    int mid = (lo + hi) / 2;

                    if (arr[mid] > arr[hi])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi= mid;
                    }
                }

                return lo;
            }
            public static int FindElement(int[] arr, int ele)
            {
                int n = arr.Length;
                int pivot = FindPivot(arr, 0, arr.Length-1);

                if (arr[pivot] == ele)
                {
                    return pivot;
                }

                if (pivot == 0)
                {
                    return BinarySearch(arr, ele, 0, n - 1);
                }

                if (arr[0] <= ele)
                {
                    return BinarySearch(arr, ele, 0, pivot - 1);
                }

                return BinarySearch(arr, ele, pivot + 1, n - 1);

            }
        }

        public static class SearchInRotatedSortedArrayUsingSingleBinarySearch
        {
            public static int FindElement(int[] arr, int key)
            {

                // Initialize two pointers, lo and hi, at the start
                // and end of the array
                int lo = 0, hi = arr.Length - 1;

                while (lo <= hi)
                {
                    int mid = lo + (hi - lo) / 2;

                    // If key found, return the index
                    if (arr[mid] == key)
                        return mid;

                    // If Left half is sorted
                    if (arr[mid] >= arr[lo])
                    {

                        // If the key lies within this sorted half,
                        // move the hi pointer to mid - 1
                        if (key >= arr[lo] && key < arr[mid])
                            hi = mid - 1;

                        // Otherwise, move the lo pointer to mid + 1
                        else
                            lo = mid + 1;
                    }

                    // If Right half is sorted
                    else
                    {

                        // If the key lies within this sorted half,
                        // move the lo pointer to mid + 1
                        if (key > arr[mid] && key <= arr[hi])
                            lo = mid + 1;

                        // Otherwise, move the hi pointer to mid - 1
                        else
                            hi = mid - 1;
                    }
                }

                // Key not found
                return -1;
            }
        }
        //Time Complexity O(n) Space Complexity O(1)
        public static int[] LeftRotate(int[] arr, int m)
        {
            int n = arr.Length;
            m = m % n;
            int i, j;
            for (i = n-m, j = n - 1; i < j; i++,j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            for(i=0,j=n-m-1; i < j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            for (i = 0,j=n-1; i<j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return arr;
        }
        public static void main()
        {
            int[] arr = [0, 1, 2, 3, 4, 5, 6, 7];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            arr = LeftRotate(arr, 3);
            Console.WriteLine("--------------");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            int index = SearchInRotatedSortedArrayUsingTwoBinarySearch.FindElement(arr, 3);
            Console.WriteLine("--------------");
            Console.WriteLine(index);

            int index2 = SearchInRotatedSortedArrayUsingSingleBinarySearch.FindElement(arr, 3);
            Console.WriteLine("--------------");
            Console.WriteLine(index2);

        }
    }
}
