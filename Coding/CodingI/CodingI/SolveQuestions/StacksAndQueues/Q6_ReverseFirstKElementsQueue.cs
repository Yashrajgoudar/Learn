namespace CodingI.SolveQuestions.StacksAndQueues
{
    internal class Q6_ReverseFirstKElementsQueue
    {
        public static Queue<int> ReverseKElements(Queue<int> queue, int k)
        {
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while(stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            int rem = queue.Count - k;
            for(int i = 0; i < rem; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }


            return queue;
        }

        public static void PrintQueue(Queue<int> queue)
        {
            foreach(int i in queue)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
        public static void main()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            PrintQueue(queue);

            ReverseKElements(queue, 3);
            PrintQueue(queue);
        }
    }
}
