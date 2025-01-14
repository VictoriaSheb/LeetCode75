public class Program
{
    public static void Main()
    {
        Solution soluton = new Solution();
        int iter = 0;
        while (true)
        {
            Console.WriteLine(soluton.CloseStrings(Console.ReadLine(), Console.ReadLine()));
            iter++;
        }
    }
}

public class Solution
{
    public bool CloseStrings(string word1, string word2)
    {
        if(word1.Count() != word2.Count())
            return false;
        List<int> values1 = new List<int>();
        int[] values2;
        Dictionary<int, int> keysAndPosition = new Dictionary<int, int>();
        int iter = 0;
        foreach (int ch in word1)
        {
            if (keysAndPosition.ContainsKey(ch))
                values1[keysAndPosition[ch]]++;
            else
            {
                keysAndPosition.Add(ch, iter++);
                values1.Add(1);
            }
        }
        values2 = new int[values1.Count()];
        Array.Fill(values2, 0);
        foreach (int ch in word2) 
        {
            if (keysAndPosition.ContainsKey(ch))
                values2[keysAndPosition[ch]]++;
            else
                return false;
        }
        values1.Sort();
        Array.Sort(values2);
        for (int i = 0; i < values1.Count; i++)
        {
            if (values1[i] != values2[i])
                return false;
        }
        return true;
    }
}