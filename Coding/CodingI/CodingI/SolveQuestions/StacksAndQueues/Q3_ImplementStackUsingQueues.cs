using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI.SolveQuestions.Stacks
{
    public class Q3_ImplementStackUsingQueues
    {

        public class myStack
        {           
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            public void Push(int val)
            {
                q1.Enqueue(val);
            }

            public void Pop()
            {
                while(q1.Count !=1)
                {
                    q2.Enqueue(q1.Dequeue());
                }

                q1.Dequeue();
                var temp = q1;
                q1 = q2;
                q2 = temp;

            }
        }

        public static void main()
        {
            myStack myStack = new myStack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            myStack.Pop();
        }
    }
}
