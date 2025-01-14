

public class Progpam
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.IncreasingTriplet(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));
    }
}

class Solution
{
    public bool IncreasingTriplet(int[] nums)
    {
        int num1 = nums[0];
        int? num2 = null;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == num1)
                continue;
            if (nums[i] < num1)
                num1 = nums[i];
            else
            {
                if (num2 is not null)
                {
                    if (nums[i] <= num2)
                        num2 = nums[i];
                    else
                        return true;
                }
                else 
                {
                    num2 = nums[i];
                }

            }
        }
        return false;
    }

}