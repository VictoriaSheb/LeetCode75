

public class Program
{
    public static void Main()
    {
        Solution soluton = new Solution();
        while(true)
            Console.WriteLine(soluton.PivotIndex(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));
    }
}

public class Solution
{
    public int PivotIndex(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++) 
        {
            nums[i] += nums[i - 1];
        }
        int lastNum = nums.Last();
        if ((lastNum - nums[0]) == 0)
            return 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == (lastNum - nums[i-1]))
                return i;
        }
        return -1;
    }
}