namespace CodingI.RequiredProblems.Array
{
    public class ArraySorting
    {
        //Selection Sort Time Complexity: O(n^2) Space Complexity: O(1)
        public int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min_index = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_index])
                        min_index = j;
                }
                (arr[i], arr[min_index]) = (arr[min_index], arr[i]);   //Tuple Swapping

                //Below is the equivalent Traditional Swapping Method
                //int temp = arr[i];
                //arr[i] = arr[min_index];
                //arr[min_index] = temp;
            }
            return arr;
        }

        //Bubble Sort Time Complexity: O(n^2) Space Complexity: O(1)
        public int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool isSorted = false;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        isSorted = true;
                    }
                }
                if (!isSorted)
                    break;
            }
            return arr;
        }

        //Insertion Sort Time Complexity: O(n^2) Space Complexity: O(1)
        public int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i], j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        //Merge Sort Time Complexity: O(n log n) Space Complexity: O(n)
        public class MergeSorting()
        {
            //Time Complexity: O(n)
            public void Merge(int[] arr, int start, int end, int mid)
            {
                List<int> temp = [];

                int i = start, j = mid + 1;
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

                for(int idx = 0; idx < temp.Count; idx++)
                {
                    arr[start + idx] = temp[idx];
                }
            }
            public void Divide(int[] arr,int start,int end)
            {
                if(start < end)
                {
                    int mid = start + (end - start) / 2;
                    Divide(arr,start, mid);
                    Divide(arr, mid + 1, end);
                    Merge(arr, start, end, mid);
                }
            }
            public int[] MergeSort(int[] arr)
            {
                Divide(arr, 0, arr.Length - 1);
                return arr;
            }
        }

        //Time Complexity: O(n^2) Space Complexity: O(1)
        public class QuickSorting()
        {
            //Partitioning is the process of selecting a pivot element from the array and partitioning the other elements into two sub-arrays according to whether they are less than or greater than the pivot.
            public int Partition(int[] arr, int start, int end)
            {
                int idx = start - 1;
                int pivot = arr[end];
                for(int j = start; j < end; j++)
                {
                    if (arr[j] <= pivot)
                    {
                        idx++;
                        (arr[idx], arr[j]) = (arr[j], arr[idx]);
                    }
                }

                idx++;
                (arr[idx], arr[end]) = (arr[end], arr[idx]);
                return idx;
            }
            public void Sort(int[] arr, int start, int end)
            {
                if (start<end)
                {
                    int pivotIdx = Partition(arr, start, end);
                    Sort(arr, start, pivotIdx - 1);  //Left Sub-array
                    Sort(arr,pivotIdx+1,end);  //Right Sub-array
                }
            }
            //The QuickSort algorithm works by selecting a pivot element from the array and partitioning the other elements into two sub-arrays, according to whether they are less than or greater than the pivot.
            public int[] QuickSort(int[] arr)
            {
                Sort(arr, 0, arr.Length - 1);
                return arr;
            }
        }

        //Counting Sort is a non-comparison based sorting algorithm that is efficient for sorting integers within a known range.
        //Time Complexity: O(n + k) where n is the number of elements in the input array and k is the range of the input values. Space Complexity: O(k) for the count array.
        public int[] CountingSorting(int[] arr)
        {
            int n = arr.Length;
            int maxValue = 0;
            for(int i = 0; i < n; i++)
            {
                maxValue = Math.Max(maxValue, arr[i]);
            }
            int[] countArray = new int[maxValue + 1];
            for(int i = 0; i < n; i++)
            {
                countArray[arr[i]]++;
            }
            for(int i = 1; i < maxValue+1; i++)
            {
                countArray[i] += countArray[i - 1];
            }
            int[] outputArray=new int[n];
            for(int i = n-1; i >=0; i--)
            {
                outputArray[countArray[arr[i]] - 1] = arr[i];
                countArray[arr[i]]--;
            }
            return outputArray;
        }
    }
}
