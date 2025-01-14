public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };

        var entrance = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
        var result = solution.FindKthLargest(entrance, 4);


        Console.WriteLine(result);
    }
}


public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        for (int i = 0; i < nums.Length; i++) 
        {
            priorityQueue.Enqueue(nums[i], -nums[i]);
        }
        while (k-- != 1) 
        {
            priorityQueue.Dequeue();
        }
        return priorityQueue.Dequeue();
    }
}