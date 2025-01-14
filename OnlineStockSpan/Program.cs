public class Program
{
    public static void Main()
    {
        StockSpanner solution = new StockSpanner();

        Console.WriteLine(solution.Next(31));
        Console.WriteLine(solution.Next(41));
        Console.WriteLine(solution.Next(48));
        Console.WriteLine(solution.Next(59));
        Console.WriteLine(solution.Next(79));
    }
}


public class StockSpanner
{
    private List<(int vl, int next)> values;
    public StockSpanner()
    {
        values = new List<(int, int)>();
    }

    public int Next(int price)
    {
        if (values.Count == 0)
        {
            values.Add((price, 0));
            return 1;
        }
        var currentId = values.Count - 1;
        var result = 1;
        while (values[currentId].vl <= price && currentId != 0)
        {
            result += values[currentId].next;
            currentId -= values[currentId].next;
        }
        if (values[currentId].vl <= price && currentId == 0)
            result++;
        values.Add((price, (result == 1) ? 1 : result - 1));
        return result;
    }
}
