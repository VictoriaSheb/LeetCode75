
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(4);
     //   CreateTree(new int?[] { 10, 8, 12, 6, 5, null, 15, 4, 3, null, 1 }, treeNode, 1, 1);
        CreateTree(new int?[] { 2, 7, 1, 3 }, treeNode, 1, 1);
        var val = solution.SearchBST(treeNode, 2);
        Console.WriteLine(solution.SearchBST(treeNode, 3));
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




public class Solution
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if(root is null || root.val == val)
            return root;
        if (root.val > val)
            return SearchBST(root.left, val);
        else
            return SearchBST(root.right, val);
    }
}