namespace CodingI.SolveQuestions.LinkedList
{
    public class Q3_MergeTwoSortedLists
    {
        public static Node MergeSortedList(Node list1,Node list2)
        {            
            if (list1 == null)
                return list2;
            if (list2 == null) return list1;

            Node dummy = new Node(-1);
            Node newList = dummy;

            while(list1 != null && list2 != null)
            {
                if(list1.Data < list2.Data)
                {
                    newList.Next = list1;
                    list1 = list1.Next;
                }
                else
                {
                    newList.Next = list2;
                    list2 = list2.Next;
                }
                newList = newList.Next;
            }

            newList.Next = list1 ?? list2;

            return dummy.Next;
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
            Node node1 = new Node(10);
            Node node2 = new Node(10);
            Node node3 = new Node(20);
            Node node4 = new Node(30);
            Node node5 = new Node(10);
            Node node6 = new Node(20);
            Node node7 = new Node(30);
            Node node8 = new Node(40);

            Node list1 = node1;
            Node list2 = node5;

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            
            PrintLL(list1);
            Console.WriteLine("-------------------------");
            PrintLL(list2);
            Console.WriteLine("-------------------------");
            PrintLL(MergeSortedList(list1, list2));

        }
    }
}
