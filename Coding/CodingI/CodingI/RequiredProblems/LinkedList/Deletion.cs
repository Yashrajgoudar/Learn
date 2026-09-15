namespace CodingI.RequiredProblems.LinkedList
{
    public class Deletion
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }
        public class Program
        {
            public static Node DeleteAtBeginning(Node head)
            {
                if (head == null)
                    return head;
                head = head.Next;
                return head;
            }

            public static Node DeleteAtEnd(Node head)
            {
                if (head == null)
                    return null;
                if (head.Next == null)
                    return null;
                Node secondLast = head;
                while (secondLast.Next.Next != null)
                {
                    secondLast = secondLast.Next;
                }
                secondLast.Next = null;
                return head;
            }

            public static Node DeleteAtPoint(Node head, int pos)
            {
                if (head == null || pos<=0)
                    return null;
                if (pos==1)
                    return head.Next;

                Node curr = head;
                Node prev = null;
                for(int i=1;i<pos && curr != null; i++)
                {
                    prev = curr;
                    curr = curr.Next;
                }
                prev.Next = curr.Next;
                return head;
            }

            public static void PrintLL(Node head)
            {
                while(head != null)
                {
                    Console.WriteLine(head.Data);
                    head = head.Next;
                }
            }
            public static void main()
            {
                Node head = new Node(10);
                head.Next = new Node(20);
                head.Next.Next = new Node(30);
                head.Next.Next.Next = new Node(40);
                head.Next.Next.Next.Next = new Node(50);
                head.Next.Next.Next.Next.Next = new Node(60);

                PrintLL(head);
                Console.WriteLine("--------------");
                head = DeleteAtBeginning(head);
                PrintLL(head);
                Console.WriteLine("--------------");
                head = DeleteAtEnd(head);
                PrintLL(head);
                Console.WriteLine("--------------");
                head = DeleteAtPoint(head, 3);
                PrintLL(head);
            }
        }
    }
}
