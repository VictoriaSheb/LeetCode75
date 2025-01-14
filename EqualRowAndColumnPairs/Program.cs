



using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution soluton = new Solution();
        //int[][] grid = new int[][] { new int[] { 3, 2, 1 }, 
        //                             new int[] { 1, 7, 6 },
        //                             new int[] { 2, 7, 7}
        //                           };
        int[][] grid = new int[][] { new int[] { 3, 1, 2, 2 },
                                     new int[] { 1, 4, 4, 5 },
                                     new int[] { 2, 4, 2, 2},
                                     new int[] { 2, 4, 2, 2},
                                   };

        Console.WriteLine(soluton.EqualPairs(grid));
    }
}

public class Solution
{

    public int EqualPairs(int[][] grid)
    {
        int countEquals = 0;
        Dictionary<string, int> keyValuePairsRows= new Dictionary<string, int>();
        string strNums;
        foreach (int[] pair in grid)
        {
            strNums = string.Join(" ", pair);
            if (keyValuePairsRows.ContainsKey(strNums))
                keyValuePairsRows[strNums]++;
            else
                keyValuePairsRows.Add(strNums, 1);
        }
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            strNums = string.Join(" ", grid.Select(pair => pair[i]));
            if (keyValuePairsRows.ContainsKey(strNums))
                countEquals += keyValuePairsRows[strNums];
        }
        return countEquals;
    }
}