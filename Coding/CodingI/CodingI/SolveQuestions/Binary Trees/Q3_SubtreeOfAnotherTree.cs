namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q3_SubtreeOfAnotherTree
    {
        public static bool AreIdentical(TreeNode? node1, TreeNode node2)
        {
            if(node1 == null && node2==null) return true;
            if(node1 == null || node2==null) return false;

            return node1.Data == node2.Data && AreIdentical(node1.left, node2.left) && AreIdentical(node1.right, node2.right);
        }
        public static bool IsSubtree(TreeNode? node1, TreeNode node2)
        {
            if(node2==null) return true;
            if(node1==null) return false;

            if(AreIdentical(node1, node2)) return true;

            return IsSubtree(node1.left, node2) || IsSubtree(node1.right, node2);
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

            // Construct Tree root2
            //          10
            //         /  \
            //        4    6
            //         \
            //          30
            TreeNode root2 = new TreeNode(10);
            root2.right = new TreeNode(6);
            root2.left = new TreeNode(4);
            root2.left.right = new TreeNode(30);

            Console.WriteLine(IsSubtree(root1, root2));
        }
    }
}
