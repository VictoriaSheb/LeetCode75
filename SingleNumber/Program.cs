public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.SingleNumber(new int[] { 4, 1, 2, 1, 2 });
        Console.WriteLine(result);
    }
}


public class Solution
{

    public int SingleNumber(int[] nums)
    {
        var hSet = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hSet.Contains(nums[i]))
                hSet.Remove(nums[i]);
            else
                hSet.Add(nums[i]);
        }
        return hSet.First();
    }
}
