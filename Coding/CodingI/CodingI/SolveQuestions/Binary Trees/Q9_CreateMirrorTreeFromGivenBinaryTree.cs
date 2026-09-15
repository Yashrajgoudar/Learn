namespace CodingI.SolveQuestions.Binary_Trees
{
    public class Q9_CreateMirrorTreeFromGivenBinaryTree
    {
        public static TreeNode CreateNode(int val)
        {
            TreeNode node = new TreeNode(val);
            node.right = null;
            node.left = null;
            return node;
        }

        public static TreeNode CreateMirrorTree(TreeNode node)
        {
            if(node == null)
            {
                return null;
            }
            TreeNode mirror = CreateNode(node.Data);

            mirror.left = CreateMirrorTree(node.right);
            mirror.right = CreateMirrorTree(node.left);

            return mirror;

        }

        public static void MirrorTree(TreeNode node)
        {
            if (node == null)
                return;

            // swap left and right
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;

            // recurse
            MirrorTree(node.left);
            MirrorTree(node.right);
        }
        public static void InOrderTraversal(TreeNode node)
        {
            if(node == null)
            {
                return;
            }

            InOrderTraversal(node.left);
            Console.WriteLine(node.Data);
            InOrderTraversal(node.right);
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
            InOrderTraversal(root1);
            Console.WriteLine("------------------");

            TreeNode reversedNode = CreateMirrorTree(root1);

            InOrderTraversal(reversedNode);

            MirrorTree(root1);
            Console.WriteLine("----------------");

            InOrderTraversal(root1 );
        }
    }
}
