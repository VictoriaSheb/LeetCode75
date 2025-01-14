

using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution soluton = new Solution();
        int iter = 0;
        while (true)
        {
            Console.WriteLine(soluton.UniqueOccurrences(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()));
            iter++;
        }
    }
}

public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> valuePairs= new Dictionary<int, int>();
        foreach (int num in arr) 
        {
            if(valuePairs.ContainsKey(num))
                valuePairs[num]++;
            else
                valuePairs.Add(num, 1);
        }
        int[] values = valuePairs.Values.ToArray();
        Array.Sort(values);
        for (int i = 1; i < values.Length; i++)
            if (values[i] == values[i - 1])
                return false;
        return true;
    }
}