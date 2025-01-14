using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.MaxProfit(new int[] { 1, 3, 7, 5, 10, 3 }, 3);
        Console.WriteLine(result);
    }
}

public class Solution
{
    public int MaxProfit(int[] prices, int fee)
    {
        int profit = 0;
        int minPrice = prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
                minPrice = prices[i];
            else if (prices[i] > minPrice + fee)
            {
                profit += prices[i] - minPrice - fee;
                minPrice = prices[i] - fee;
            }
        }
        return profit;
    }
}

//public class Solution
//{
//    public int MaxProfit(int[] prices, int fee)
//    {
//        var ln = prices.Length;
//        if (ln == 1)
//            return 0;
//        var downSums = new int[ln];
//        var lastMaxSums = new int[ln];

//        int sum;
//        for (int i = ln - 1; i >= 0; i--)
//        {
//            if (i == (ln - 1) || prices[i] < prices[i + 1])
//                for (int j = ln - 1; j > i; j--)
//                {
//                    sum = prices[j] - prices[i] - fee + lastMaxSums[j];
//                    downSums[j] = sum > downSums[j] ? sum : downSums[j];
//                    downSums[j - 1] = downSums[j - 1] > downSums[j] ? downSums[j - 1] : downSums[j];
//                    if (j == i + 1)
//                        lastMaxSums[i] = downSums[j];
//                }
//            else
//            {
//                lastMaxSums[i] = lastMaxSums[i + 1];
//            }
//        }
//        return lastMaxSums[0] > 0 ? lastMaxSums[0] : 0;
//    }
//}