namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q2_ReverseLevelOrderTraversal
    {
        public static List<List<int>> FindReverseLevelOrder(TreeNode node)
        {
            if (node == null) return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            Stack<List<int>> stack = new Stack<List<int>>();
            List<List<int>> res = new List<List<int>>();

            queue.Enqueue(node);
            int currLevel = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;
                List<int> levelList = new List<int>();

                for(int i = 0; i < len; i++)
                {
                    TreeNode curr = queue.Dequeue();
                    levelList.Add(curr.Data);

                    if(curr.left!=null) queue.Enqueue(curr.left);
                    if(curr.right!=null) queue.Enqueue(curr.right);                    
                }
                stack.Push(levelList);
            }

            foreach(List<int> s in stack)
            {
                res.Add(s);
            }
            return res;
        }
        public static void main()
        {
            TreeNode firstNode = new TreeNode(1);
            TreeNode secondNode = new TreeNode(2);
            TreeNode thirdNode = new TreeNode(3);
            TreeNode fourthNode = new TreeNode(4);
            TreeNode fifthNode = new TreeNode(5);
            TreeNode sixthNode = new TreeNode(6);

            firstNode.left = secondNode;
            firstNode.right = thirdNode;
            secondNode.left = fourthNode;
            secondNode.right = fifthNode;
            thirdNode.right = sixthNode;

            List<List<int>> levelOrderRecRes = new List<List<int>>();

            levelOrderRecRes= FindReverseLevelOrder(firstNode);

            foreach (List<int> i in levelOrderRecRes)
            {
                foreach (int j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
