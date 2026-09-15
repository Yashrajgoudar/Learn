namespace CodingI.RequiredProblems.Stacks
{
    public class StackUsingDynamicArray
    {
        public List<int> newList=new List<int>();
        
        public void Push(int x)
        {
            newList.Add(x);
        }

        public int Pop()
        {
            if (newList.Count == 0)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            int pop_ele=newList[newList.Count-1];
            newList.RemoveAt(newList.Count - 1);
            return pop_ele;
        }

        public int Peek()
        {
            return newList[newList.Count-1];
        }

        public void PrintStack()
        {
            for(int i = newList.Count-1; i >= 0; i--)
            {
                Console.Write(newList[i]+",");
            }
            Console.WriteLine();
        }
        public static void main()
        {
            StackUsingDynamicArray stack = new StackUsingDynamicArray();

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
