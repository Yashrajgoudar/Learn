namespace CodingI.SolveQuestions.StacksAndQueues
{
    public class Q5_ImplementStackQueueUsingDeque
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public class DeQue
        {
            public Node head;
            public Node tail;

            public DeQue()
            {
                head = tail = null;
            }

            public bool isEmpty()
            {
                return head == null;
            }

            public int size()
            {
                int count = 0;
                Node curr = head;
                while (curr != null)
                {
                    count++;
                    curr = curr.next;
                }
                return count;
            }

            public void insert_first(int val)
            {
                Node node = new Node(val);
                head.next = node;
                head = node;
            }
        }
    }
}
