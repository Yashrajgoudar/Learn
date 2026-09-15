namespace CodingI.SolveQuestions.Binary_Trees
{
    public class TreeNode
    {
        public int Data;
        public TreeNode? left, right;

        public TreeNode(int data)
        {
            this.Data = data;
            left = null;
            right = null;
        }
    }
    public class Q1__MaximumDepthOfBinaryTree
    {

        public static int FindMaxLengthRec(TreeNode node)
        {
            if (node == null) return 0;

            int left = FindMaxLengthRec(node.left);
            int right = FindMaxLengthRec(node.right);

            return Math.Max(left, right) + 1;
        }

        public static int FindMaxLengthQueue(TreeNode node)
        {
            if(node == null) return 0;
            int maxLength = 0;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                int len = q.Count;

                for(int i = 0; i < len; i++)
                {
                    TreeNode curr = q.Dequeue();
                    if (curr.left != null) q.Enqueue(curr.left);
                    if (curr.right != null) q.Enqueue(curr.right);
                }
                maxLength++;
            }
            return maxLength;
        }
        public static void main()
        {
            // Create binary tree
            //       1
            //      /  \
            //    2     3
            //   / \     \
            //  4   5     6

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

            Console.WriteLine(FindMaxLengthRec(firstNode));
            Console.WriteLine(FindMaxLengthQueue(firstNode));
        }
    }
}
