



public class Program
{
    public static void Main()
    { 
        Solution solution = new Solution();
        var spells = new int[] { 1, 2};
        Console.WriteLine(solution.FindPeakElement(spells));
    }
}


public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1, pick = right / 2;
        if (left == right)
            return 0;
        if (nums[left] > nums[left + 1])
            return left;
        if (nums[right] > nums[right - 1])
            return right;
        while (!(nums[pick-1] < nums[pick] && nums[pick] > nums[pick+1])) 
        {
            if (nums[pick - 1] > nums[pick])
                right = pick;
            else
                left = pick;
            pick = left + (right - left) / 2;
            if ((right - left) == 1 && (!(nums[pick - 1] < nums[pick] && nums[pick] > nums[pick + 1])))
                pick = left = right;
        }
        return pick;
    }
}

