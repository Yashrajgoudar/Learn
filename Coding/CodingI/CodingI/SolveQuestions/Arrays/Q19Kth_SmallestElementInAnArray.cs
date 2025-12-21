using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI.SolveQuestions.Arrays
{
    internal class Q19Kth_SmallestElementInAnArray
    {
        //Approach 1 - Max-Heap to get kth smallest
        public static int FindKthSmallestMaxHeap(int[] nums, int k)
        {
            //Simulate max-heap using negative priorities
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

            foreach (int num in nums)
            {
                maxHeap.Enqueue(-num, -num); // negate for max-heap behavior

                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }

            return -maxHeap.Peek(); // negate back
        }

        //Approach 2 - Quick Select
        public class FindKthSmallestQuickSelect
        {
            public int FindKthSmallest(int[] nums, int k)
            {
                return QuickSelect(nums, 0, nums.Length - 1, k - 1); // kth smallest → index = k - 1
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
        public static int FindKthSmallestSorting(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[k - 1]; // kth smallest → index = k - 1
        }

        public static void main(string[] args)
        {
            int[] arr = { 7, 10, 4, 3, 20, 15 };
            int k = 3;

            Console.WriteLine("Using Max-Heap: " + FindKthSmallestMaxHeap(arr, k));
            Console.WriteLine("Using Sorting: " + FindKthSmallestSorting(arr, k));

            FindKthSmallestQuickSelect quickSelect = new FindKthSmallestQuickSelect();
            Console.WriteLine("Using QuickSelect: " + quickSelect.FindKthSmallest(arr, k));
        }
    }
}
