public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };

        var one = new int[] { 1, 3, 3, 2 };
        var two = new int[] { 2, 1, 3, 4 };
        Console.WriteLine(solution.MaxScore(one, two, 3));
    }
}




public class Solution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        List<(int value, int id)> nums = new List<(int value, int id)>();
        var len = nums1.Length;

        for (int i = 0; i < len; i++)
            nums.Add((nums1[i], nums2[i]));
        nums = nums.OrderBy(num => num.id).ToList();
        
        long result = -1, partResult = 0; 
        PriorityQueue<int, int> maxs = new PriorityQueue<int, int>(k-1);
        for (int i = len - k + 1; i<len; i++)
        {
            maxs.Enqueue(nums[i].value, nums[i].value);
            partResult += nums[i].value;
        }
        int currentId, help;
        for (int i = len - k; i >= 0; i--) 
        {
            currentId = nums[i].id;
            help = k-1;
            result = Math.Max(result, (partResult + nums[i].value) * (long) currentId);
            if (maxs.Count>0 && nums[i].value > maxs.Peek())
            {
                partResult -= maxs.Dequeue();
                partResult += nums[i].value;
                maxs.Enqueue(nums[i].value, nums[i].value);
            }
        }
        return result;
    }

    //public int[] BubbleSort(int[] array)
    //{
    //    var len = array.Length;
    //    int[] sortedArray = new int[len];
    //    for (int i = 0; i < len; i++) 
    //    {
    //        sortedArray[i] = i;
    //    }
    //    for (var i = 1; i < len; i++)
    //    {
    //        for (var j = 0; j < len - i; j++)
    //        {
    //            if (array[sortedArray[j]] > array[sortedArray[j + 1]])
    //            {
    //                (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]);
    //            }
    //        }
    //    }
    //    return sortedArray;
    //}


}