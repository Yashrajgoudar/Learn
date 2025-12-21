namespace CodingI.SolveQuestions.Arrays
{
    internal class Q10Kth_LargestElementInAnArray
    {
        //Approach 1 - min-heap (priority queue)
        public static int FindKthLargestMinHeap(int[] nums, int k)
        {
            // Min-heap to store k largest elements
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            foreach (int num in nums)
            {
                minHeap.Enqueue(num, num); // Enqueue with value as priority

                if (minHeap.Count > k)
                {
                    minHeap.Dequeue(); // Remove smallest if more than k elements
                }
            }

            // Top of the min-heap is the kth largest
            return minHeap.Peek();
        }


        //Approach 2 - Quick Select
        public class FindKthLargestQuickSelect
        {
            public int FindKthLargest(int[] nums, int k)
            {
                int n = nums.Length;
                return QuickSelect(nums, 0, n - 1, n - k);
            }

            private int QuickSelect(int[] nums, int left, int right, int kSmallest)
            {
                if (left == right)
                    return nums[left];

                int pivotIndex = Partition(nums, left, right);

                if (pivotIndex == kSmallest)
                    return nums[pivotIndex];
                else if (pivotIndex > kSmallest)
                    return QuickSelect(nums, left, pivotIndex - 1, kSmallest);
                else
                    return QuickSelect(nums, pivotIndex + 1, right, kSmallest);
            }

            private int Partition(int[] nums, int left, int right)
            {
                int pivot = nums[right];
                int i = left;

                for (int j = left; j < right; j++)
                {
                    if (nums[j] <= pivot)
                    {
                        Swap(nums, i, j);
                        i++;
                    }
                }

                Swap(nums, i, right);
                return i;
            }

            private void Swap(int[] nums, int a, int b)
            {
                int temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
            }
        }



        //Approach 3 - Sorting
        public static int FindKthLargestSorting(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }


        public static void main(string[] args)
        {
            int[] arr = { 1, 2, 3, 1, 5 };
            int kLargest = FindKthLargestMinHeap(arr,3);
            int kLargestSort = FindKthLargestSorting(arr,3);

            FindKthLargestQuickSelect findKthLargest = new FindKthLargestQuickSelect();
            int kLargestSortQuickSelect = findKthLargest.FindKthLargest(arr, 3);
            Console.WriteLine(kLargestSortQuickSelect);
        }
    }
}
