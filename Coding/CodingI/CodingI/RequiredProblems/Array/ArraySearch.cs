namespace CodingI.RequiredProblems.Array
{
    public class ArraySearch
    {
        //Linear Search
        public int LinearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return i;
                }
            }
            return 0;
        }

        //Binary Search
        public int BinarySearch(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (arr[mid] < key)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return 0;
        }

        //Recursive Binary Search
        public int RecursiveBinarySearch(int[] arr, int key, int left, int right)
        {
            if (left > right)
                return -1;
            int mid = (left + right) / 2;
            if (arr[mid] == key)
                return mid;
            else if (arr[mid] < key)
            {
                return RecursiveBinarySearch(arr, key, mid + 1, right);
            }
            else
                return RecursiveBinarySearch(arr, key, left, mid - 1);
        }
    }
}
