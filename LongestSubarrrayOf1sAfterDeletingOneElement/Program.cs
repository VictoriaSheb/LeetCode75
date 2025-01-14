using System.Text;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestSubarray(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));

    }
}

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int maxCount = 0, firstPart, secondPart = 0;
        for (int i = 0; i < nums.Length; i++) 
        {
            firstPart = 0;
            while ((i<nums.Length) && (nums[i] == 1))
            {
                firstPart++;
                i++;
            } 
            maxCount = Math.Max(maxCount, firstPart + secondPart);
            if(i>=1)
                secondPart = ((i + 1) >= nums.Length) ? 0 : (((nums[i - 1] == 1) && (nums[i + 1] == 1)) ? firstPart : 0);
        }
        if (maxCount == nums.Count())
            maxCount--;
        return maxCount;
    }
}