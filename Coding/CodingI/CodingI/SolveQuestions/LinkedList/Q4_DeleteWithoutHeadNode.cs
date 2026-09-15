namespace CodingI.SolveQuestions.LinkedList
{
    public class Q4_DeleteWithoutHeadNode
    {
        public static void DeleteNode(Node delNode)
        {
            if (delNode == null || delNode.Next == null)
                return;
            Node tempNode = delNode.Next;
            delNode.Data = tempNode.Data;
            delNode.Next = tempNode.Next;
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
            Console.WriteLine("---------------");
            DeleteNode(node3);
            PrintLL(list);
            Console.WriteLine("---------------");
        }
    }
}
