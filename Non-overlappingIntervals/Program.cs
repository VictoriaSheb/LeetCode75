public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.EraseOverlapIntervals(new int[][] {
            new int[]{ 1, 2 },
            new int[]{ 2, 3},
            new int[]{ 3, 4},
            new int[]{ 1, 3}
        });
        Console.WriteLine(result);
    }
}


public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        var sum = 0;
        var goods = new Dictionary<int, int>();
        foreach ( var interval in intervals ) 
        {
            if (goods.ContainsKey(interval[0]))
            {
                goods[interval[0]] = Math.Min(goods[interval[0]], interval[1]);
                sum++;
            }
            else
                goods.Add(interval[0], interval[1]);
        }
        var lastKey =int.MaxValue;
        foreach (var gd in goods.OrderByDescending(gd => gd.Key)) 
        {
            if (gd.Value > lastKey)
                sum++;
            else
                lastKey = gd.Key;
        }
        return sum;
    }
}