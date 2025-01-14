using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.Rob(new int[] { 1, 2, 8, 2, 1, 10 });

        //  var result = solution.HouseRobber(new int[] { 228, 67, 195, 15, 0, 90, 151, 210, 17, 196, 0, 10, 28, 110, 169, 94, 9, 23, 52, 63, 136, 122, 22, 191, 144, 22, 173, 106, 88, 59, 200, 156, 39, 109, 244, 231, 183, 99, 114, 15, 114, 32, 57, 36, 117, 151, 177, 106, 229, 188, 178, 47, 96, 191, 25, 180, 153, 187, 136, 146, 117, 57, 77, 110, 215, 115, 84, 218, 59, 121, 202, 109, 205, 95, 214, 100, 175, 50, 223, 11, 14, 164, 224, 15, 100, 241, 61, 64, 197, 206, 3, 149, 108, 186 });

        Console.WriteLine(result);
    }
}

class Solution
{
    public Dictionary<int, int> maxSums;

    public int Rob(int[] money)
    {
        maxSums = new Dictionary<int, int>();
        return SearchMax(money, 0, money.Length - 1);
    }

    private int GetMaxSum(int[] money, int start, int end)
    {
        if (start == end)
            return money[start];
        if (start + 1 == end)
            return Math.Max(money[start], money[end]);

        if (maxSums.ContainsKey(start))
            return maxSums[start];
        return SearchMax(money, start, end);
    }

    private int SearchMax(int[] money, int start, int end) 
    {
        var lenghtMiniMoney = money.Length - start;
        if (lenghtMiniMoney == 1)
            return money[start];
        if (lenghtMiniMoney == 2)
            return Math.Max(money[start], money[end]);


        int id = start + 1;
        var sum1 = GetMaxSum(money, start, id - 1);
        var sum2 = GetMaxSum(money, id + 1, money.Length - 1);

        if (!maxSums.ContainsKey(id + 1))
            maxSums.Add(id + 1, sum2);

        var maxSum = Math.Max(sum1 + sum2, money[id]);

        if (lenghtMiniMoney == 3)
            return maxSum;

        id++;
        sum1 = GetMaxSum(money, start, id - 1);
        sum2 = GetMaxSum(money, id + 1, money.Length - 1);

        if (!maxSums.ContainsKey(id + 1))
            maxSums.Add(id + 1, sum2);

        return Math.Max(maxSum, Math.Max(sum1 + sum2, money[id]));
    }
}