public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        Console.WriteLine(result);
    }
}

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        if (temperatures.Length == 1)
            return new int[] { 0 };
        var result = new int[temperatures.Length];
        int max = temperatures[temperatures.Length - 1];
        int tempId;
        for (int i = temperatures.Length - 2; i >= 0; i--)
        {
            if (max <= temperatures[i])
                result[i] = 0;
            else
            {
                result[i] = 1;
                tempId = i + 1;
                while (temperatures[tempId] <= temperatures[i])
                {
                    result[i] += result[tempId];
                    tempId += result[tempId];
                }
            }
            max = Math.Max(max, temperatures[i]);
        }
        return result;
    }
}