namespace CodingI.RequiredProblems.LinkedList
{
    public class Insertion
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

        public class InsertionAtBeginning
        {
            private Node head;
            public InsertionAtBeginning()
            {
                head = null;
            }
            public void InsertAtBeginning(int data)
            {
                Node node = new Node(data);
                node.Next = head;
                head = node;
            }

            public void PrintLL()
            {
                while (head != null)
                {
                    Console.WriteLine(head.Data);
                    head = head.Next;
                }
            }
        }

        public class InsertionAtEnd
        {
            public static Node InsertAtEnd(Node head, int newData)
            {
                Node newNode = new Node(newData);
                if(head == null)
                {
                    return newNode;
                }
                Node last = head;
                while(last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = newNode;
                return head;
            }

            public static Node InsertAtBeginning(Node head, int newData)
            {
                Node newNode = new Node(newData);
                if(head == null)
                {
                    return newNode;
                }
                newNode.Next = head;
                head = newNode;
                return head;
            }

            public static void PrintLL(Node node)
            {
                while(node != null)
                {
                    Console.WriteLine(node.Data);
                    node = node.Next;
                }
            }
        }

        public class InsertionAtPosition
        {
            public static Node InsertAtPosition(Node head, int pos, int newData)
            {
                if (pos < 1)
                {
                    return head;
                }

                Node newNode = new Node(newData);

                if (pos == 1)
                {
                    newNode.Next = head;
                    head = newNode;
                    return head;
                }

                Node curr = head;

                for(int i=1;i<pos-1 && curr != null; i++)
                {
                    curr = curr.Next;
                }

                if(curr == null)
                {
                    return head;
                }

                newNode.Next = curr.Next;
                curr.Next = newNode;
                return head;
            }
        }

        public class Program
        {
            public static void main(string[] args)
            {
                InsertionAtBeginning head = new InsertionAtBeginning();
                head.InsertAtBeginning(10);
                head.InsertAtBeginning(20);
                head.InsertAtBeginning(30);
                head.InsertAtBeginning(40);
                head.PrintLL();


                Node head1 = new Node(10);
                head1.Next = new Node(20);
                head1.Next.Next = new Node(30);
                head1.Next.Next.Next = new Node(40);

                head1 = InsertionAtEnd.InsertAtEnd(head1, 50);
                head1 = InsertionAtEnd.InsertAtBeginning(head1, 60);

                head1 = InsertionAtPosition.InsertAtPosition(head1, 3, 70);

                InsertionAtEnd.PrintLL(head1);

            }
        }
    }
}
