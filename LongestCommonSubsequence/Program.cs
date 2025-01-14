using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.LongestCommonSubsequence("bsbininm", "jmjkbkjkv");
        Console.WriteLine(result);
    }
}


public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var sums = new int[text1.Length, text2.Length];
        int U, L, D;
        for (int i = 0; i < text1.Length; i++)
        {
            for (int j = 0; j < text2.Length; j++)
            {
                U = (j - 1 >= 0) ? sums[i, j - 1] : 0;
                L = (i - 1 >= 0) ? sums[i - 1, j] : 0;
                D = ((i - 1 >= 0) && (j - 1 >= 0)) ? sums[i - 1, j - 1] : 0;
                sums[i, j] = (text1[i] == text2[j]) ? D + 1 : Math.Max(U, L);
            }
        }
        return sums[text1.Length -1 , text2.Length -1 ];

    }
}