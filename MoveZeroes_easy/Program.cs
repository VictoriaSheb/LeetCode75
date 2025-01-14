

public class Progpam
{
    public static void Main()
    {
        Solution solution = new Solution();
        solution.MoveZeroes(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
    }
}

//  

class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int shift = 0;
        for (int i = 0; i < nums.Length; i++) 
        {
            if (nums[i] == 0)
                shift++;
            else
            { 
                nums[i - shift] = nums[i];
                if ((nums.Length - i) <= shift)
                    nums[i] = 0;
            }
        }
        
    }
}