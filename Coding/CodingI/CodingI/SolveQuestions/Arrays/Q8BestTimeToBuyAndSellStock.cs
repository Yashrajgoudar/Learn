using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI.SolveQuestions.Arrays
{
    public class Q8BestTimeToBuyAndSellStock
    {
        //Brute Force Approach Time Complexity O(n2)
        public static int MaxProfit(int[] prices)
        {
            int prof = 0;
            int n = prices.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int price = prices[j] - prices[i];
                    if (price > prof)
                    {
                        prof = price;
                    }
                }
            }
            return prof;
        }

        //Optimized Solution with Time Complexity O(n)
        public static int MaxProfitOptimized(int[] prices)
        {
            int minPrice=int.MaxValue;
            int maxProfit=0;
            foreach (int price in prices)
            {
                if (price<minPrice)
                {
                    minPrice = price;
                }
                else
                {
                    int profit=price-minPrice;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit;
        }

        public static void main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int prof = MaxProfit(arr);
            int prof2 = MaxProfitOptimized(arr);
            Console.WriteLine(prof2);
        }
    }
}
