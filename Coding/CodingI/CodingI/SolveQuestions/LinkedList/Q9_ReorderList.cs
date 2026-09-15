namespace CodingI.SolveQuestions.LinkedList
{
    public class Q9_ReorderList
    {
        public static Node ReverseLL(Node node)
        {
            Node prev = null;
            Node next = null;
            Node curr = node;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
        public static Node Rearrange(Node node)
        {
            if (node == null) return null;

            Node fast = node;
            Node slow = node;

            while (fast != null && fast.Next!=null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Node firsthalf = node;
            Node secondhalf = slow.Next;
            slow.Next = null;

            secondhalf = ReverseLL(secondhalf);

            Node dummy = new Node(0);
            Node curr = dummy;

            while(firsthalf!=null || secondhalf != null)
            {
                if (firsthalf != null)
                {
                    curr.Next = firsthalf;
                    curr = curr.Next;
                    firsthalf = firsthalf.Next;
                }

                if(secondhalf != null)
                {
                    curr.Next = secondhalf;
                    curr = curr.Next;
                    secondhalf = secondhalf.Next;
                }
            }

            return dummy.Next;
        }
        public static void PrintLL(Node head)
        {
            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
        }
        public static void main()
        {
            Node node = new Node(1);
            node.Next = new Node(2);
            node.Next.Next = new Node(3);
            node.Next.Next.Next = new Node(4);
            node.Next.Next.Next.Next = new Node(5);
            PrintLL(node);

            node = Rearrange(node);
            Console.WriteLine("-------------");
            PrintLL(node);
        }
    }
}
