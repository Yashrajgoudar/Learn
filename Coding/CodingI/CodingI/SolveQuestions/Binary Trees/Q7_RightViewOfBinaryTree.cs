namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q7_RightViewOfBinaryTree
    {
        public static void FindRightViewDFS(TreeNode node, int level, List<int> ans)
        {
            if(node == null) return;

            if(level == ans.Count)
            {
                ans.Add(node.Data);
            }

            FindRightViewDFS(node.right, level + 1, ans);
            FindRightViewDFS(node.left, level + 1, ans);
        }
        public static void FindRightViewBFS(TreeNode node, int level, List<int> ans)
        {
            if (node == null) return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                int levelSize = q.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode curr = q.Dequeue();

                    // If it's the first node of the current level
                    if (i == levelSize-1)
                        ans.Add(curr.Data);

                    if (curr.left != null) q.Enqueue(curr.left);
                    if (curr.right != null) q.Enqueue(curr.right);
                }
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
            FindRightViewDFS(root1, 0, ans);

            foreach (int i in ans)
            {
                Console.WriteLine(i);
            }
        }
    }
}
