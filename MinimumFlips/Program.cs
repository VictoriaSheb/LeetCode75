public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.MinFlips(4, 2, 7);
        Console.WriteLine(result);
    }
}


public class Solution
{
    public int MinFlips(int a, int b, int c)
    {
        var result = 0;
        var x = (a | b) ^ c;
        var y = (a & b) & (~c);

        while (x != 0) 
        {
            if (x % 2 == 0)
                x = x / 2;
            else
            {
                x--;
                result++;
            }

            if (y != 0) 
            {
                if (y % 2 == 0)
                    y = y / 2;
                else
                {
                    y--;
                    result++;
                }
            }
        }
        return result;
    }
}