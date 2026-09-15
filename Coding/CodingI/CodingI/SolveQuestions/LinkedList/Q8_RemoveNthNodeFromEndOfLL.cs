namespace CodingI.SolveQuestions.LinkedList
{
    public class Q8_RemoveNthNodeFromEndOfLL
    {
        //Time Complexity O(2n) Space Complexity O(1)
        public static Node RemoveNodeApproach1(Node head, int n)
        {
            if(head == null) return null;
            int c = 0;
            Node ptr = head;
            while (ptr != null)
            {
                c++;
                ptr = ptr.Next;
            }

            if (c == n)
            {
                head = head.Next;
                return head;
            }

            if (n > c || n < 0) return head;

            ptr = head;

            int idx = 0;
            while (idx < c - n -1)
            {
                ptr = ptr.Next;
                idx++;
            }
            ptr.Next = ptr.Next.Next;
            return head;
        }

        //Two Pointor Approach Time Complexity O(n) and Space Complexity O(1)
        public static Node RemoveNodeApproach2(Node head, int n)
        {
            Node fast = head;
            Node slow = head;

            for(int i = 0; i < n; i++)
            {
                if (fast == null) return head;
                fast = fast.Next;
            }

            if(fast == null) return head.Next;

            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            slow.Next = slow.Next.Next;
            return head;
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
            Console.WriteLine("----------------------");
            node = RemoveNodeApproach2(node, 5);
            PrintLL(node);
        }
    }
}
