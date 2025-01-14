public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.CountBits(5);
        Console.WriteLine(result);
    }
}
public class Solution
{
    public int[] CountBits(int n)
    {
        var bits = new int[n + 1];
        var ch = false;
        for (int i = 1; i <= n; i++) 
        {
            if (ch) 
            {
                bits[i] = bits[i/2];
            }
            else
                bits[i] = bits[i-1] + 1;
            ch = !ch;
        }
        return bits;
    }
}