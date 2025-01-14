

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.FindMaxAverage(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));
    }
}

//  
public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        double maxSum = nums.Take(k).Sum();
        double currentSum = maxSum;
        for (int i = k; i < nums.Length; i++) 
        {
            currentSum += -nums[i - k] + nums[i];
            if (currentSum > maxSum)
                maxSum = currentSum;
        }
        return maxSum / (double)k;

    }
}