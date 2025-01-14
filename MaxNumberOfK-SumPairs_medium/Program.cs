

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaxOperations(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));
    }
}

//  

public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0, right = nums.Length-1;
        int result = 0;
        while (!(left >= right)) 
        {
            if ((nums[left] + nums[right]) == k) 
            {
                left++;
                right--;
                result++;
            }
            else
            {
                if ((k - nums[right]) > nums[left])
                    left++;
                else
                    right--;
            }
        }
        return result;
    }
}