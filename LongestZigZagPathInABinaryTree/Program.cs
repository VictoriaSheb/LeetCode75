using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(10);
        // CreateTree(new int?[] { 1, null, 1, 1, 1, null, null, 1, 1, 1, null, null, null, 1 }, treeNode, 1, 1);
        CreateTree(new int?[] { 1, 2, 3, 4, 5, null, null, null, null, 6, null }, treeNode, 1, 1);
        Console.WriteLine(solution.LongestZigZag(treeNode));
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
    public int LongestZigZag(TreeNode root)
    {
        return Math.Max(SearchPathSum(root.left, true, 0), SearchPathSum(root.right, false, 0));
    }

    public int SearchPathSum(TreeNode root, bool left, int beforePath)
    {
        if (root is null)
            return beforePath;
        int maxPath = beforePath;
        maxPath = Math.Max(maxPath, SearchPathSum(root.right, false, (left) ? (beforePath + 1) : 0));
        maxPath = Math.Max(maxPath, SearchPathSum(root.left, true, (!left) ? (beforePath + 1) : 0));       
        return maxPath;
    }
}


