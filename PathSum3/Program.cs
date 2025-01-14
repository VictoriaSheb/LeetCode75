using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        TreeNode treeNode = new TreeNode(10);
        CreateTree(new int?[] { 10, 5, -3, 3, 2, null, 11, 10, -2, null, 1 }, treeNode, 1, 1);
        Console.WriteLine(solution.PathSum(treeNode, 8));
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
            CreateTree(values, treeNode.left, (int)(Math.Pow(2, level + 1) -1 +  2 * (idValues - (Math.Pow(2, level) - 1))), level + 1);
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

//    int ans;
//    public int PathSum(TreeNode root, int targetSum)
//    {

//        Dictionary<long, int> prefixsum = new Dictionary<long, int>();
//        prefixsum.Add(0, 1);
//        ans = 0;
//        count(root, targetSum, 0, prefixsum);
//        return ans;
//    }

//    void count(TreeNode root, int sum, long cur, Dictionary<long, int> prefixsum)
//    {
//        if (root == null)
//            return;

//        cur += root.val;

//        if (prefixsum.ContainsKey(cur - sum))
//            ans += prefixsum[cur - sum];

//        if (prefixsum.ContainsKey(cur))
//            prefixsum[cur]++;
//        else
//            prefixsum.Add(cur, 1);

//        count(root.left, sum, cur, prefixsum);
//        count(root.right, sum, cur, prefixsum);

//        if (prefixsum[cur] == 1)
//            prefixsum.Remove(cur);
//        else
//            prefixsum[cur]--;

//    }
//}

//public class Solution
//{
//    public int PathSum(TreeNode root, int targetSum)
//    {
//        Dictionary<long, int> keyValuePairs = new Dictionary<long, int>();
//        keyValuePairs.Add(0, 1);
//        return SearchPathSum(root, targetSum, keyValuePairs, 0);
//    }

//    public int SearchPathSum(TreeNode root, int targetSum, Dictionary<long, int> prefixSumValues, long sumAll)
//    {
//        if (root is null)
//            return 0;
//        int countSums = 0, countValues = prefixSumValues.Count;
//        long newSum = root.val + sumAll - targetSum;

//        if (prefixSumValues.ContainsKey(newSum))
//            countSums = prefixSumValues[newSum];
//        newSum += targetSum;
//        if (prefixSumValues.ContainsKey(newSum))
//            prefixSumValues[newSum]++;
//        else
//            prefixSumValues.Add(newSum, 1);
//        sumAll += newSum;
//        countSums += SearchPathSum(root.left, targetSum, prefixSumValues, sumAll);
//        countValues++;
//        if (countValues < prefixSumValues.Count)
//            prefixSumValues.RemoveRange(countValues, prefixSumValues.Count - countValues);
//        countSums += SearchPathSum(root.right, targetSum, prefixSumValues);
//        return countSums;
//    }
//}




public class Solution
{
    public int PathSum(TreeNode root, int targetSum)
    {
        List<long> prefixSumValues = new List<long>() { 0 };
        return SearchPathSum(root, targetSum, prefixSumValues);
    }

    public int SearchPathSum(TreeNode root, int targetSum, List<long> prefixSumValues)
    {
        if (root is null)
            return 0;
        int countSums = 0;
        long newSum = root.val + prefixSumValues.Last() - targetSum;
        countSums = prefixSumValues.Count(sum => sum == newSum);
        prefixSumValues.Add(newSum + targetSum);
        countSums += SearchPathSum(root.left, targetSum, prefixSumValues);
        countSums += SearchPathSum(root.right, targetSum, prefixSumValues);
        prefixSumValues.RemoveAt(prefixSumValues.Count - 1);
        return countSums;
    }
}

