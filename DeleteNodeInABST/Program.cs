
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //int?[] tree = new int?[] { 5, 3, 6, 2, 4, null, 7 };
        int?[] tree = new int?[] { 37, 18, 39, 15, 29, null, null, 10, 11, 20, 30, null, null, null, null, null, null, null, null, null, 22 };
        TreeNode treeNode = new TreeNode(tree[0]??(0));
        CreateTree(tree, treeNode, 1, 1);
      //  CreateTree(new int?[] { 37, 18, 39, 15, 29, null, null, 10, 11, 20, 30, null, null, null, null, null, null, null, null, null, 22 }, treeNode, 1, 1);
        var val = solution.DeleteNode(treeNode, 18);
        Console.WriteLine(solution.DeleteNode(treeNode, 18));
    }

    public static void CreateTree(int?[] values, TreeNode treeNode, int idValues, int level)
    {
        if (idValues >= values.Count())
            return;
        if (values[idValues] is null)
            treeNode.left = null;
        else
        {
            treeNode.left = new TreeNode((int)values[idValues]);
            CreateTree(values, treeNode.left, (int)(Math.Pow(2, level + 1) - 1 + 2 * (idValues - (Math.Pow(2, level) - 1))), level + 1);
        }
        if (++idValues >= values.Count())
            return;
        if (values[idValues] is null)
            treeNode.right = null;
        else
        {
            treeNode.right = new TreeNode((int)values[idValues]);
            CreateTree(values, treeNode.right, (int)(Math.Pow(2, level + 1) - 1 + 2 * (idValues - (Math.Pow(2, level) - 1))), level + 1);
        }
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


//public class Solution
//{
//    public TreeNode DeleteNode(TreeNode root, int key)
//    {
//        if (root == null) return root;

//        if (root.val == key)
//        {
//            if (root.left == null && root.right == null)
//            {
//                return null;
//            }
//            else if (root.left == null)
//            {
//                return root.right;
//            }
//            else if (root.right == null)
//            {
//                return root.left;
//            }
//            else
//            {
//                var leftMost = LeftMost(root.right);

//                root.val = leftMost.val;
//                root.right = DeleteNode(root.right, root.val);

//                return root;
//            }
//        }
//        else if (root.val < key)
//        {
//            root.right = DeleteNode(root.right, key);
//        }
//        else
//        {
//            root.left = DeleteNode(root.left, key);
//        }

//        return root;
//    }

//    public TreeNode LeftMost(TreeNode node)
//    {
//        return node.left == null ? node : LeftMost(node.left);
//    }
//}


public class Solution
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is not null && root.val == key)
        {
            var zeroRoot = new TreeNode(root.val);
            zeroRoot.left = root;
            DeleteNode(zeroRoot, true);
            return zeroRoot.left;
        }
        SearchBST(root, key);
        return root;
    }

    public void SearchBST(TreeNode root, int val)
    {
        if (root is null)
            return;
        if (root.val > val)
        {
            if (root.left is not null && root.left.val == val)
                DeleteNode(root, true);
            else
                SearchBST(root.left, val);
        }
        else
        {
            if (root.right is not null && root.right.val == val)
                DeleteNode(root, false);
            else
                SearchBST(root.right, val);
        }
    }

    public void DeleteNode(TreeNode root, bool leftNode)
    {
        TreeNode deleteNode = (leftNode) ? root.left : root.right;
        if (deleteNode.left is null)
        {
            if (leftNode)
                root.left = deleteNode.right;
            else
                root.right = deleteNode.right;
        }
        else if (deleteNode.right is null)
        {
            if (leftNode)
                root.left = deleteNode.left;
            else
                root.right = deleteNode.left;
        }
        else
        {
            var beforeNode = deleteNode.right;
            var replacement = deleteNode.right;
            while (replacement.left is not null)
            {
                beforeNode = replacement;
                replacement = replacement.left;
            }
            beforeNode.left = replacement.right;
            replacement.left = deleteNode.left;
            replacement.right = (deleteNode.right == replacement) ? replacement.right : deleteNode.right;

            if (leftNode)
                root.left = replacement;
            else
                root.right = replacement;
        }
    }

}