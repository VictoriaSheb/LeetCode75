using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode =  new TreeNode(1);
        treeNode.left = new TreeNode(2);
        //treeNode.right = new TreeNode(3);
        //treeNode.right.left = new TreeNode(4);
        //treeNode.right.right = new TreeNode(5);
        Console.WriteLine(solution.MaxDepth(treeNode));
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
    public int MaxDepth(TreeNode root)
    {
        if (root is null)
            return 0;
        int dephtLeft = 1, dephRight = 1;
        if (root.left is not null)
        {
            dephtLeft += MaxDepth(root.left); 
        }
        if (root.right is not null)
        {
            dephRight += MaxDepth(root.right); 
        }
        return Math.Max(dephtLeft, dephRight);
    }
}