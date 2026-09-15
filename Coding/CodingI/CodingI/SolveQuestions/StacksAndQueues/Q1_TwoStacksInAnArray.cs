namespace CodingI.SolveQuestions.Stacks
{
    public class Q1_TwoStacksInAnArray
    {
        private int[] arr;
        private int top1;
        private int top2;
        private int size;
        public Q1_TwoStacksInAnArray(int capacity)
        {
            arr = new int[capacity];
            size = capacity;
            top1 = -1;
            top2 = capacity;
        }

        public void Push1(int x)
        {
            if (top1 >= top2-1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            arr[++top1] = x;
            return;
        }

        public void Push2(int x)
        {
            if (top1 >= top2-1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            arr[--top2] = x;
            return;
        }

        public int Pop1()
        {
            if (top1 == -1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            return arr[top1--];
        }

        public int Pop2()
        {
            if (top2 == size)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            return arr[top2++];
        }

        public static void main()
        {
            Q1_TwoStacksInAnArray ts = new Q1_TwoStacksInAnArray(5);
            ts.Push1(2);
            ts.Push1(3);
            ts.Push2(4);
            Console.Write(ts.Pop1() + " ");
            Console.Write(ts.Pop2() + " ");
            Console.Write(ts.Pop2() + " ");
        }
    }
}
