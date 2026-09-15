namespace CodingI.RequiredProblems.Stacks
{
    public class StackUsingArray
    {
        private int[] arr;
        private int capacity;
        private int top;

        public StackUsingArray(int cap)
        {
            capacity = cap;
            arr = new int[capacity];
            top = -1;
        }

        public void Push(int x)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            top++;
            arr[top] = x;
        }

        public int Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            return arr[top--];
        }

        public int Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            return arr[top];
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }

            for(int i = top; i >= 0; i--)
            {
                Console.Write(arr[i]+",");
            }
            Console.WriteLine();
        }

        public static void main()
        {
            StackUsingArray stack = new StackUsingArray(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.PrintStack();
            Console.WriteLine("Poping Element "+ stack.Pop());
            stack.PrintStack();
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);
            stack.PrintStack();
            Console.WriteLine("Peeking Element " + stack.Peek());
            stack.PrintStack();
        }
    }
}
