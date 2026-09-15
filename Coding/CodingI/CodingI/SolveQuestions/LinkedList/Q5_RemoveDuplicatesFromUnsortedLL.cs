namespace CodingI.SolveQuestions.LinkedList
{
    public class Q5_RemoveDuplicatesFromUnsortedLL
    {
        public static Node RemoveDuplicateLL(Node head)
        {
            if (head == null)
                return null;
            Node prev = null;
            Node curr = head;
            HashSet<int> tmp = new HashSet<int>();
            while (curr != null)
            {
                if (tmp.Contains(curr.Data))
                {
                    prev.Next = curr.Next;
                }
                else
                {
                    prev = curr;
                    tmp.Add(curr.Data);
                }
                curr = curr.Next;
            }
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
        public static void main(string[] args)
        {
            Node node1 = new Node(10);
            Node node2 = new Node(10);
            Node node3 = new Node(20);
            Node node4 = new Node(30);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            Node list = node1;

            PrintLL(list);
            Console.WriteLine("--------------");
            RemoveDuplicateLL(list);
            PrintLL(list);
        }
    }
}
