using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI.SolveQuestions.LinkedList
{
    public class Q2_LinkedListCycle
    {
        //Floyd’s Cycle Detection (Tortoise & Hare) Algorithm
        //Time Complexity O(n) Space Complexity O(1)
        public static bool IsLLCycle(Node head)
        {
            Node slow = head;
            Node fast = head;
            while (fast!=null && fast.Next!=null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        public static void main()
        {
            Node node1 = new Node(10);
            Node node2 = new Node(10);
            Node node3 = new Node(10);
            Node node4 = new Node(10);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node2;   //Cycle

            Node head = node1;

            Console.WriteLine(IsLLCycle(head));

        }
    }
}
