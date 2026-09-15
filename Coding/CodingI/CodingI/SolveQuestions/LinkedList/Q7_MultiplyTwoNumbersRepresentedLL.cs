namespace CodingI.SolveQuestions.LinkedList
{
    public class Q7_MultiplyTwoNumbersRepresentedLL
    {
        public static int GenerateNum(Node node)
        {
            int num = 0;
            while (node != null)
            {
                num = num * 10 + node.Data;
                node = node.Next;
            }

            return num;
        }
        public static int MultiplyLL(Node node1, Node node2)
        {
            int num1=GenerateNum(node1);
            int num2=GenerateNum(node2);
            return num1 * num2;
        }
        public static void main()
        {
            Node node1 = new Node(1);
            node1.Next = new Node(0);
            node1.Next.Next = new Node(0);

            Node node2 = new Node(1);
            node2.Next = new Node(0);

            Console.WriteLine(MultiplyLL(node1, node2));
        }
    }
}
