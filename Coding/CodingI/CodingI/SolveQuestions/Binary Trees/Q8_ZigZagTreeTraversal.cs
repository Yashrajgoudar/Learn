namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q8_ZigZagTreeTraversal
    {
        public static void FindZigZagTraversal(TreeNode node, int level, List<int> ans)
        {
            if(node == null) return;
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            stack1.Push(node);

            while(stack1.Count > 0 || stack2.Count > 0)
            {
                if (level % 2 == 0)
                {
                    while (stack1.Count > 0)
                    {
                        TreeNode currNode = stack1.Pop();
                        if (currNode.left != null) stack2.Push(currNode.left);
                        if (currNode.right != null) stack2.Push(currNode.right);
                        ans.Add(currNode.Data);
                    }
                }
                else
                {
                    while(stack2.Count > 0)
                    {
                        TreeNode currNode = stack2.Pop();
                        if (currNode.right != null) stack1.Push(currNode.right);
                        if (currNode.left != null) stack1.Push(currNode.left);
                        ans.Add(currNode.Data);
                    }
                }

                level++;
            }

        }
        public static void main()
        {
            // Construct Tree root1
            //          26
            //         /  \
            //        10   3
            //       / \    \
            //      4   6    3
            //       \
            //        30
            TreeNode root1 = new TreeNode(26);
            root1.right = new TreeNode(3);
            root1.right.right = new TreeNode(3);
            root1.left = new TreeNode(10);
            root1.left.left = new TreeNode(4);
            root1.left.left.right = new TreeNode(30);
            root1.left.right = new TreeNode(6);

            List<int> ans = new List<int>();
            FindZigZagTraversal(root1, 0, ans);

            foreach (int i in ans)
            {
                Console.WriteLine(i);
            }
        }
    }
}
