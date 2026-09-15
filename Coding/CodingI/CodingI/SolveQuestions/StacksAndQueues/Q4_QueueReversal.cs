namespace CodingI.SolveQuestions.StacksAndQueues
{
    public class Q4_QueueReversal
    {
        public static Queue<int> ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while(stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }
        public static void main()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            foreach (var item in queue)
            {
                Console.Write(item+",");
            }
            Console.WriteLine();

            ReverseQueue(queue);

            while (queue.Count>0)
            {
                Console.Write(queue.Dequeue()+",");
            }
        }
    }
}
