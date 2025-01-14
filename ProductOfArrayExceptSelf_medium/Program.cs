

public class Progpam
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(String.Join(" ",solution.ProductExceptSelf(Console.ReadLine().Split(" ").Select(int.Parse).ToArray())));
    }
}

class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] newNums = new int[nums.Length];
        Array.Fill(newNums, 1);
        int leftToRight = 1;
        int rightToLeft = 1;
        for(int i=1; i<nums.Length; i++) 
        {
            leftToRight *= nums[i-1];
            newNums[i] *= leftToRight;
            rightToLeft *= nums[^i];
            newNums[^(i + 1)] *= rightToLeft;
        }
        return newNums;
    }

}