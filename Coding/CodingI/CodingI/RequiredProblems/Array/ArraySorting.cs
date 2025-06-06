namespace CodingI.RequiredProblems.Array
{
    public class ArraySorting
    {
        //Selection Sort
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

        //Bubble Sort
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

        //Insertion Sort
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
    }
}
