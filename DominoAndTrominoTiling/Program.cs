public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.NumTilings(60);
        Console.WriteLine(result);
    }
}

public class Solution
{
    public int NumTilings(int n)
    {
        var modVal = (long)Math.Pow(10, 9) + 7;
        long nSumMinus1 = 2;
        long nSumMinus2 = 1;
        long newSum = 2 * 1; 
        long nSum = 0;

        if (n == 1) 
            return (int)nSumMinus2;
        if (n == 2) 
            return (int)nSumMinus1;
        
        for (int i = 3; i <= n; i++) 
        {
            nSum = (nSumMinus1 + nSumMinus2 + newSum) % modVal;
            newSum += 2 * nSumMinus2;
            nSumMinus2 = nSumMinus1;
            nSumMinus1 = nSum;
        }
        return (int)nSum;
    }
}