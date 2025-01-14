public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.FindMinArrowShots(new int[][] {
            new int[]{ 10, 16 },
            new int[]{ 2, 8},
            new int[]{ 1, 6},
            new int[]{ 7, 12}
        });
        Console.WriteLine(result);
    }
}

public class Solution
{
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (a, b) => b[0].CompareTo(a[0]));
        var current0 = points[0][0];
        int sum = 1;
        foreach (var point in points)
        {
            if (current0 != point[0] && (point[1] < current0))
            {
                sum++;
                current0 = point[0];
            }
        }
        return sum;
    }
}