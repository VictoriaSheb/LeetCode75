

public class Program 
{
    public static void Main() 
    {
        Solution soluton = new Solution();
        Console.WriteLine(soluton.LargestAltitude(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));
    }
}

public class Solution 
{
    public int LargestAltitude(int[] gain) 
    {
        int maxHighest = 0, currentHighest = 0;
        foreach (int g in gain) 
        {
            currentHighest += g;
            if(currentHighest>maxHighest)
                maxHighest = currentHighest;
        }
        return maxHighest;
    }
}