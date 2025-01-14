using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode1 = new TreeNode(1);
        TreeNode treeNode2 = new TreeNode(2);
        //treeNode.right = new TreeNode(3);
        //treeNode.right.left = new TreeNode(4);
        //treeNode.right.right = new TreeNode(5);
        Console.WriteLine(solution.LeafSimilar(treeNode1, treeNode2));
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

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        ListNode listNode1, listNode2;
        listNode1 = new ListNode(-1);
        listNode2 = new ListNode(-1);
        LookInLeaves(root1, listNode1);
        LookInLeaves(root2, listNode2);
        bool result = true;
        while (listNode1 is not null && listNode2 is not null) 
        {
            result &= listNode1.val == listNode2.val;
            listNode2 = listNode2.next;
            listNode1 = listNode1.next;
        }
        return (listNode1 is null && listNode2 is null) && result;
    }

    public ListNode LookInLeaves(TreeNode root, ListNode node)
    {
        if (root.left is null && root.right is null) 
        {
            if (node.val == -1)
                node.val = root.val;
            else 
            {
                node.next = new ListNode(root.val);
                node = node.next;
            }
            return node;
        }
        if (root.left is not null)
            node = LookInLeaves(root.left, node);
        if (root.right is not null)
            node = LookInLeaves(root.right, node);
        return node;
    }

    public int LookInLeaves(TreeNode root, int hash)
    {
        if (root.left is null && root.right is null)
            return (hash == 0) ? root.val : (unchecked(hash + 314159) * root.val);
        if (root.left is not null)
            hash = LookInLeaves(root.left, hash);
        if (root.right is not null)
            hash = LookInLeaves(root.right, hash);
        return hash;
    }

}



//public class Solution
//{
//    public bool LeafSimilar(TreeNode root1, TreeNode root2)
//    {
//        return LookInLeaves(root1, 0) == LookInLeaves(root2, 0);
//    }

//    public int LookInLeaves(TreeNode root, int hash)
//    {
//        if (root.left is null && root.right is null)
//            return (hash == 0) ? root.val : (unchecked(hash + 314159) * root.val);
//        if (root.left is not null)
//            hash = LookInLeaves(root.left, hash);
//        if (root.right is not null)
//            hash = LookInLeaves(root.right, hash);
//        return hash;
//    }
//}




//public long GetHash(int[] data)
//{
//    long result = 0;

//    var power = 179;
//    var modulo = 179424673;

//    foreach(var num in data)
//    {
//        result = (result + (long) power * num) % modulo;
//        power = (power * 179) % modulo; 
//    }

//    return result;
//}