public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        foreach(bool res in (solution.KidsWithCandies(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), int.Parse(Console.ReadLine()))))
            Console.WriteLine(res);

    }
}

public class Solution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        int maxCandy = candies.Max();
        return candies.Select(candy => (candy + extraCandies) >= maxCandy).ToList();
    }
}