
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(10);
        CreateTree(new int?[] { 10, 5, -3, 3, 2, null, 11, 12, -2, null, 1 }, treeNode, 1, 1);
        Console.WriteLine(solution.LowestCommonAncestor(treeNode, treeNode.left.left, treeNode.right.right).val);
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
    HashSet<TreeNode> roots;
    TreeNode generalNode;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        generalNode = null;
        roots = new HashSet<TreeNode>();
        SearchPath(root, p.val);
        SearchNode(root, q.val);
        return generalNode??(root);

    }
   
    private bool SearchNode(TreeNode root, long value)
    {
        if (root == null) return false;
        if (root.val == value)
        {
            if(roots.Contains(root)) 
            {
                generalNode = root;
                return false;
            }
            return true;
        }
        if (SearchNode(root.left, value) || SearchNode(root.right, value))
        {
            if (roots.Contains(root))
            {
                generalNode = root;
                return false;
            }
            else
                return true;
        }
        return false;
    }

    private bool SearchPath(TreeNode root, long value) 
    {
        if (root == null) return false;
        if (root.val == value)
        {
            roots.Add(root);
            return true;
        }
        if (SearchPath(root.left, value) || SearchPath(root.right, value))
        {
            roots.Add(root);
            return true;
        }
        return false;        
    }
}