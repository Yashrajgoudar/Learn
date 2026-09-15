namespace CodingI.SolveQuestions.LinkedList
{
    public class Q6_SortLLOf0s1s2s
    {
        public class Node
        {
            public int data;
            public Node Next;
            public Node(int data)
            {
                this.data = data;
                Next = null;
            }
        }

        public static void SortList(Node head)
        {
            int[] arr = { 0, 0, 0 };
            Node ptr= head;

            while (ptr != null)
            {
                arr[ptr.data]++;
                ptr = ptr.Next;
            }

            int idx = 0;
            ptr=head;

            while (ptr != null)
            {
                if (arr[idx] == 0)
                {
                    idx++;
                }
                else
                {
                    ptr.data = idx;
                    arr[idx]--;
                    ptr = ptr.Next;
                }
            }
        }

        public static void PrintLL(Node head)
        {
            while (head != null)
            {
                Console.WriteLine(head.data);
                head = head.Next;
            }
        }

        public static void main()
        {
            Node node = new Node(1);
            node.Next = new Node(1);
            node.Next.Next = new Node(2);
            node.Next.Next.Next = new Node(0);
            node.Next.Next.Next.Next = new Node(2);
            node.Next.Next.Next.Next.Next = new Node(0);
            node.Next.Next.Next.Next.Next.Next = new Node(1);

            SortList(node);
            PrintLL(node);
        }
    }
}
