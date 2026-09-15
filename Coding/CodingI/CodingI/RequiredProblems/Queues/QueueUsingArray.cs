namespace CodingI.RequiredProblems.Queues
{
    public class QueueUsingArray
    {
        private int[] arr;
        private int capacity;
        private int size;
        public QueueUsingArray(int capacity)
        {
            arr = new int[capacity];
            this.capacity = capacity;
            size = 0;
        }

        public void EnQueue(int x)
        {
            if (size == capacity)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            arr[size++] = x;
        }

        public int DeQueue()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue Underflow");
                return -1;
            }
            int ele = arr[0];
            for(int i = 0; i < size-1; i++)
            {
                arr[i] = arr[i+1];
            }
            size--;
            return ele;
        }

        public int getFront()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue Underflow");
                return -1;
            }
            return arr[0];
        }

        public int getRear()
        {
            if (size == 0)
            {
                Console.WriteLine("Queue Underflow");
                return -1;
            }
            return arr[size - 1];
        }
        public static void main()
        {
            QueueUsingArray q = new QueueUsingArray(3);

            q.EnQueue(10);
            q.EnQueue(20);
            q.EnQueue(30);
            Console.WriteLine("Front: " + q.getFront());

            q.DeQueue();
            Console.WriteLine("Front: " + q.getFront());
            Console.WriteLine("Rear: " + q.getRear());

            q.EnQueue(40);
        }
    }
}
