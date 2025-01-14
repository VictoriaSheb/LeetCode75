using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(1);
        treeNode.left = new TreeNode(2);
        //treeNode.right = new TreeNode(3);
        //treeNode.right.left = new TreeNode(4);
        //treeNode.right.right = new TreeNode(5);
        Console.WriteLine(solution.GoodNodes(treeNode));
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
    public int GoodNodes(TreeNode root)
    {
        return CalcGoodNodes(root, root.val) + 1;
    }

    public int CalcGoodNodes(TreeNode root, int maxValue)
    {
        int currentCount = 0;
        if (root.left is not null)
            currentCount += (maxValue <= root.left.val) ?
                (CalcGoodNodes(root.left, root.left.val) + 1):
                (CalcGoodNodes(root.left,maxValue));
        if (root.right is not null)
            currentCount += (maxValue <= root.right.val) ?
                (CalcGoodNodes(root.right, root.right.val)+ 1) :
                (CalcGoodNodes(root.right, maxValue));
        return currentCount;
    }
}


