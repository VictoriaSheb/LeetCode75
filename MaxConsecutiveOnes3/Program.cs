using System.Text;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestOnes(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));

    }
}
// 1 1 1 1 1 0 0 0 0 0 1 1 1 1 0 1 1 0 0 0



public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int maxWindow = 0, currentWindow = 0;
        int helpBefore = 0;
        Queue<int> convertCountOnesBefore = new Queue<int>(k);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                helpBefore = 0;
                while ((i < nums.Length) && (nums[i] == 1))
                {
                    currentWindow++;
                    i++;
                    helpBefore++;
                }
                i--;
                maxWindow = Math.Max(maxWindow, currentWindow);
            }
            else
            {
                if (k == 0)
                    currentWindow = 0;

                if (convertCountOnesBefore.Count < k)
                {
                    convertCountOnesBefore.Enqueue(helpBefore);
                    helpBefore = 0;
                    maxWindow = Math.Max(maxWindow, ++currentWindow);
                }
                else
                {
                    if (k == 0)
                        currentWindow = 0;
                    else
                    {
                        currentWindow -= convertCountOnesBefore.Dequeue();
                        convertCountOnesBefore.Enqueue(helpBefore);
                        helpBefore = 0;
                    }
                }
            }
        }
        return maxWindow;
    }
}