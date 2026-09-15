namespace CodingI.SolveQuestions.LinkedList
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
    public class Q1_ReverseLinkedList
    {
        public static Node ReverseLL(Node head)
        {
            Node prev = null;
            Node curr = head;
            while (curr != null)
            {
                Node tempNode = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = tempNode;
            }
            return prev;
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
            Node head = new Node(10);
            head.Next = new Node(20);
            head.Next.Next = new Node(30);
            head.Next.Next.Next = new Node(40);
            head.Next.Next.Next.Next = new Node(50);
            head.Next.Next.Next.Next.Next = new Node(60);

            PrintLL(head);
            Console.WriteLine("--------------");
            head = ReverseLL(head);
            PrintLL(head);

        }
    }
}
