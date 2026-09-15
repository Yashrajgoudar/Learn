using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI.SolveQuestions.DynamicProgramming.Practice
{
    public class FibonnaciSeries
    {
        /*
        ============================================================
        Method Type: Plain Recursion (Top-Down without DP)
        ============================================================

        Idea:
            Fibonacci relation:

                fib(n)=fib(n-1)+fib(n-2)

        Recursively calculate previous two states.

        Issue:
            Same subproblems get solved repeatedly.

        Example:

                fib(5)
               /      \
           fib(4)   fib(3)
            /  \      / \
        fib(3) fib(2)...

        fib(3), fib(2) repeat many times.

        Time Complexity: O(2^n)

        Reason:
            Each call branches into two recursive calls,
            creating an exponential recursion tree.

        Space Complexity: O(n)

        Reason:
            Maximum recursion stack depth = n.
        ============================================================
        */
        public static int FindFibonnaciRecursion(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return FindFibonnaciRecursion(n - 1) + FindFibonnaciRecursion(n - 2);
        }

        /*
        ============================================================
        Method Type: Dynamic Programming - Memoization
        ============================================================

        Approach:
            Top-Down DP

        Idea:
            Store already computed answers
            to avoid recalculating states.

        Memoization:
            Recursion + Cache

        Steps:

        1. Check if state already exists
        2. Return cached value
        3. Else compute and store

        Time Complexity: O(n)

        Reason:
            Every state from 0 → n
            computed only once.

        Space Complexity: O(n) + O(n)

        Reason:

        DP array      -> O(n)
        Recursion stack -> O(n)

        Total = O(n)
        ============================================================
        */
        public static int FindFibonnaciDPMemoization(int n, int[] dp)
        {
            if (n <= 1)
            {
                return n;
            }
            if (dp[n] != -1)
            {
                return dp[n];
            }

            dp[n] = FindFibonnaciDPMemoization(n - 1, dp) + FindFibonnaciDPMemoization(n - 2, dp);

            return dp[n];
        }

        /*
        ============================================================
        Method Type: Dynamic Programming - Tabulation
        ============================================================

        Approach:
            Bottom-Up DP

        Idea:
            Start from base cases and
            iteratively build answers.

        Order:

        fib(0)
        fib(1)
        fib(2)
        fib(3)
        ...
        fib(n)

        No recursion involved.

        Time Complexity: O(n)

        Reason:
            Single loop runs from 2 → n

        Space Complexity: O(n)

        Reason:
            DP array stores n+1 values.

        Advantages:

        1. No recursion stack
        2. Faster than memoization
        3. Avoids stack overflow
        ============================================================
        */
        public static int FindFibonnaciDPTabulation(int n, int[] dp)
        {
            dp[0] = 0;
            dp[1] = 1;
            for(int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /*
        ============================================================
        Method Type: DP Space Optimization
        ============================================================

        Observation:

        dp[i]=dp[i-1]+dp[i-2]

        Current state only depends on
        previous two states.

        Instead of storing full DP array:

        [0,1,1,2,3,5,8]

        Store:

        prev2
        prev1

        Time Complexity: O(n)

        Reason:
            Single traversal from 2 → n

        Space Complexity: O(1)

        Reason:
            Only constant variables used:

        prev1
        prev2
        curr

        This is considered the optimal
        DP solution for Fibonacci.
        ============================================================
        */
        public static int FindFibonacciSpaceOptimized(int n)
        {
            int prev1 = 1;
            int prev2 = 0;

            for (int i = 2; i <= n; i++)
            {
                int curr = prev1 + prev2;
                prev2 = prev1;
                prev1 = curr;
            }

            return prev1;
        }
        public static void main()
        {
            int n = 6;
            int[] dp = Enumerable.Repeat(-1, n + 1).ToArray();
            Console.WriteLine(FindFibonnaciRecursion(n));
            Console.WriteLine(FindFibonnaciDPMemoization(n, dp));
            Console.WriteLine(FindFibonnaciDPTabulation(n, dp));
            Console.WriteLine(FindFibonacciSpaceOptimized(n));
        }
    }
}
