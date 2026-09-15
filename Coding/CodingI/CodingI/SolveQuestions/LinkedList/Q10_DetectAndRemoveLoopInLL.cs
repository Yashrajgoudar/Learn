namespace CodingI.SolveQuestions.LinkedList
{
    public class Q10_DetectAndRemoveLoopInLL
    {
        public static bool isLoop(Node node)
        {
            Node fast = node;
            Node slow = node;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if(fast==slow)
                    return true;
            }

            return false;
        }

        //Time Complexity O(n) Space Complexity O(n)
        public static Node RemoveLoopApproach1(Node node)
        {
            HashSet<Node> visited = new HashSet<Node>();
            Node curr = node;
            Node prev = null;

            while (curr != null)
            {
                if (visited.Contains(curr))
                {
                    prev.Next = null;
                    break;
                }
                visited.Add(curr);
                prev = curr;
                curr = curr.Next;
            }

            return node;
        }

        public static void RemoveLoopApproach2(Node node)
        {
            if (node == null || node.Next == null) return;
            Node fast = node;
            Node slow = node;
            while(fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow)
                    break;
            }

            if (slow == fast)
            {
                slow = node;
                if (slow != fast)
                {
                    while (slow.Next != fast.Next)
                    {
                        slow=slow.Next;
                        fast = fast.Next;
                    }
                }
                else
                {
                    while(fast.Next != slow)
                    {
                        fast = fast.Next;
                    }
                }
                fast.Next = null;
            }
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
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node3;

            Console.WriteLine(isLoop(node1));

            RemoveLoopApproach2(node1);
            Console.WriteLine(isLoop(node1));
            PrintLL(node1);
        }
    }
}
