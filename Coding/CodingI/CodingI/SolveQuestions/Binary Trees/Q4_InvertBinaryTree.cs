namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q4_InvertBinaryTree
    {
        public static TreeNode InvertBinaryTree(TreeNode node)
        {
            if (node == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int len=queue.Count;
                for(int i = 0; i < len; i++)
                {
                    TreeNode curr = queue.Dequeue();
                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);

                    TreeNode temp = curr.left;
                    curr.left = curr.right;
                    curr.right = temp;
                }
            }
            return node;
        }

        public static void LevelOrderTraversalQueue(TreeNode node, List<List<int>> res)
        {
            Queue<TreeNode> level = new Queue<TreeNode>();
            if (node == null) return;

            level.Enqueue(node);
            int currLevel = 0;

            while (level.Count > 0)
            {
                int len = level.Count;
                res.Add(new List<int>());

                for (int i = 0; i < len; i++)
                {
                    TreeNode curr = level.Dequeue();
                    res[currLevel].Add(curr.Data);
                    if (curr.left != null) level.Enqueue(curr.left);
                    if (curr.right != null) level.Enqueue(curr.right);
                }
                currLevel++;
            }
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

            Console.WriteLine("-----LevelOrder Traversal Queue--------");

            List<List<int>> beforeInvertRes = new List<List<int>>();

            LevelOrderTraversalQueue(firstNode, beforeInvertRes);

            foreach (List<int> i in beforeInvertRes)
            {
                foreach (int j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }   

            Console.WriteLine("-----LevelOrder Traversal Queue--------");
            firstNode = InvertBinaryTree(firstNode);

            List<List<int>> afterInvertRes = new List<List<int>>();

            LevelOrderTraversalQueue(firstNode, afterInvertRes);

            foreach (List<int> i in afterInvertRes)
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
