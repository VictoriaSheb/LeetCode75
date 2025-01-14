public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.UniquePaths(3, 7);
        Console.WriteLine(result);
    }
}

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var sums = new int[n, m];
        int U, L;
        sums[0, 0] = 1;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++) 
            {
                U = (j - 1 >= 0) ? sums[i, j - 1] : 0;
                L = (i - 1 >= 0) ? sums[i - 1, j] : 0;
                sums[i, j] += U + L;
            }
        return sums[n - 1,m - 1];
    }
}