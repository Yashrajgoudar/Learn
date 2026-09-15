namespace CodingI.RequiredProblems.LinkedList
{
    public class Traversal
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

        public class TraverseLinkedList
        {
            public static void TraverseLL(Node head)
            {
                while (head != null)
                {
                    Console.WriteLine(head.Data);
                    head = head.Next;
                }
            }

            public static void TraverseLLRecursive(Node head)
            {
                if(head == null)
                {
                    return;
                }
                Console.WriteLine(head.Data);
                TraverseLLRecursive(head.Next);
            }
            public static void main(string[] args)
            {
                Node head = new Node(10);
                head.Next = new Node(20);
                head.Next.Next = new Node(30);
                head.Next.Next.Next = new Node(40);
                TraverseLL(head);
                TraverseLLRecursive(head);
            }
        }
    }
}
