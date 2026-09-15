namespace CodingI.RequiredProblems.Stacks
{
    public class StackUsingLL
    {
        public class Node
        {
            public int Data;
            public Node? Next;
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node? top;
        public StackUsingLL()
        {
            top = null;
        }

        public void Push(int data)
        {
            Node node = new Node(data);
            node.Next = top;
            top = node;
        }

        public int Pop()
        {
            if(top == null)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            Node? temp = top;
            top = top.Next;
            return temp.Data;
        }

        public int Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            return top.Data;
        }

        public void PrintStack()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }

            Node? current = top;
            while (current != null)
            {
                Console.Write(current.Data+",");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public static void main()
        {
            StackUsingLL stack = new StackUsingLL();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.PrintStack();
            Console.WriteLine("Poping Element " + stack.Pop());
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
