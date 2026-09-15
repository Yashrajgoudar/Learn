namespace CodingI.RequiredProblems.LinkedList
{
    public class Searching
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
            public static void SearchingLL(Node head, int key)
            {
                while (head != null)
                {
                    if(head.Data == key)
                    {
                        Console.WriteLine("Found");
                        return;
                    }
                    head = head.Next;
                }
                Console.WriteLine("Not Found");
            }

            public static void SearchingLLRecursive(Node head, int key)
            {
                if (head == null)
                {
                    Console.WriteLine("Not Found");
                    return;
                }
                if (head.Data == key)
                {
                    Console.WriteLine("Found");
                    return;
                }
                SearchingLLRecursive(head.Next, key);
            }
            public static void main(string[] args)
            {
                Node head = new Node(10);
                head.Next = new Node(20);
                head.Next.Next = new Node(30);
                head.Next.Next.Next = new Node(40);
                int key = 30;
                SearchingLL(head, key);
                SearchingLLRecursive(head,key);
            }
        }
    }
}
