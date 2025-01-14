
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(10);
        CreateTree(new int?[] { 10, 5, -3, 3, 2, null, 11, 12, -2, null, 1 }, treeNode, 1, 1);
        foreach (var node in solution.RightSideView(treeNode))
        {
            Console.WriteLine(node);
        }
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

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        var res = new List<int>();

        if (root is null)
            return res;

        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var curLevelRight = 0;
            var lCount = q.Count;
            for (int i = 0; i < lCount; i++)
            {
                var cur = q.Dequeue();
                if (cur.left is not null) q.Enqueue(cur.left);
                if (cur.right is not null) q.Enqueue(cur.right);
                curLevelRight = cur.val;
            }
            res.Add(curLevelRight);

        }
        return res;
    }
}



//public class Solution
//{
//    IList<int> rightNodes;
//    public IList<int> RightSideView(TreeNode root)
//    {
//        rightNodes = new List<int>();
//        SearchRightNodes(root, 0);
//        return rightNodes;
//    }

//    private void SearchRightNodes(TreeNode root, int level) 
//    {
//        if (root == null)
//            return;
//        level++;
//        if (level > rightNodes.Count)
//        {
//            rightNodes.Add(root.val);
//        }
//        SearchRightNodes(root.right, level);
//        SearchRightNodes(root.left, level);
//    }
//}