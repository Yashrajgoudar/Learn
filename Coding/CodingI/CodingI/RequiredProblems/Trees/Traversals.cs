namespace CodingI.RequiredProblems.Trees
{
    public class Traversals
    {
        public class Node
        {
            public int Data;
            public Node? left, right;

            public Node(int data)
            {
                this.Data = data;
                left = null;
                right = null;
            }
        }

        static int idx = -1;
        public static Node BuildTree(int[] val)
        {
            idx++;
            if (val[idx] == -1) return null;

            Node node = new Node(val[idx]);

            node.left = BuildTree(val);
            node.right = BuildTree(val);
            return node;
        }

        public static void InOrderTraversal(Node node, List<int> res)
        {
            if (node == null) return;

            InOrderTraversal(node.left, res);

            res.Add(node.Data);

            InOrderTraversal(node.right, res);  
        }

        public static void PreOrderTraversal(Node node, List<int> res)
        {
            if(node == null) return;

            res.Add(node.Data);

            PreOrderTraversal(node.left, res);

            PreOrderTraversal(node.right, res);
        }

        public static void PostOrderTraversal(Node node, List<int> res)
        {
            if (node == null) return;

            PostOrderTraversal(node.left, res);

            PostOrderTraversal(node.right, res);

            res.Add(node.Data);
        }

        public static void LevelOrderTraversalQueue(Node node, List<List<int>> res)
        {
            Queue<Node> queue = new Queue<Node>();
            if(node == null) return;

            queue.Enqueue(node);
            int currLevel = 0;

            while (queue.Count > 0)
            {
                int len = queue.Count;
                res.Add(new List<int>());

                for(int i=0;i<len; i++)
                {
                    Node curr = queue.Dequeue();
                    res[currLevel].Add(curr.Data);
                    if(curr.left!=null) queue.Enqueue(curr.left);
                    if(curr.right!=null) queue.Enqueue(curr.right);
                }
                currLevel++;
            }
        }

        public static void LevelOrderTraversalRecursive(Node node, List<List<int>> res, int level)
        {
            if(node == null) return;

            if (res.Count == level)
            {
                res.Add(new List<int>());
            }

            res[level].Add(node.Data);

            LevelOrderTraversalRecursive(node.left, res, level + 1);
            LevelOrderTraversalRecursive(node.right, res, level + 1);
        }

        public static void main()
        {
            // Create binary tree
            //       1
            //      /  \
            //    2     3
            //   / \     \
            //  4   5     6

            Node firstNode = new Node(1);
            Node secondNode = new Node(2);
            Node thirdNode = new Node(3);
            Node fourthNode = new Node(4);
            Node fifthNode = new Node(5);
            Node sixthNode = new Node(6);

            int[] arr = [1, 2, -1, -1, 3, 4, -1, -1, 5, -1, -1];

            Node node = BuildTree(arr);

            firstNode.left = secondNode;
            firstNode.right = thirdNode;
            secondNode.left = fourthNode;
            secondNode.right = fifthNode;
            thirdNode.right = sixthNode;
            Console.WriteLine("-----InOrder Traversal--------");

            List<int> inOrderRes = new List<int>();

            InOrderTraversal(node, inOrderRes);    // 4 2 5 1 3 6

            foreach (int i in inOrderRes)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----PreOrder Traversal--------");

            List<int> preOrderRes = new List<int>();

            PreOrderTraversal(firstNode, preOrderRes);    // 1 2 4 5 3 6

            foreach (int i in preOrderRes)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----PostOrder Traversal--------");

            List<int> postOrderRes = new List<int>();

            PostOrderTraversal(firstNode, postOrderRes);     // 4 5 2 6 3 1

            foreach (int i in postOrderRes)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-----LevelOrder Traversal Queue--------");

            List<List<int>> levelOrderRes = new List<List<int>>();

            LevelOrderTraversalQueue(firstNode, levelOrderRes);

            //1
            //2 3
            //4 5 6

            foreach (List<int> i in levelOrderRes)
            {
                foreach(int j in i)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-----LevelOrder Traversal Queue--------");

            List<List<int>> levelOrderRecRes = new List<List<int>>();

            LevelOrderTraversalQueue(firstNode, levelOrderRecRes);

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
