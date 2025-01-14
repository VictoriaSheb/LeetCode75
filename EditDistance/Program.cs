public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.MinDistance("horse", "ros");
        Console.WriteLine(result);
    }
}

public class Solution
{
    // метод нахождения расстояния Левенштейна
    public int MinDistance(string word1, string word2)
    {
        var sums = new int[word1.Length + 1, word2.Length + 1];
        var max = Math.Max(word1.Length + 1, word2.Length + 1);
        for (int i = 0; i < max; i++)
        {
            if(i < word1.Length + 1)
                sums[i, 0] = i;
            if (i < word2.Length + 1)
                sums[0, i] = i;
        }
        int U, L, D;
        for (int i = 1; i < word1.Length + 1; i++)
            for (int j = 1; j < word2.Length + 1; j++)
            {
                U = sums[i, j - 1] + 1;
                L = sums[i - 1, j] + 1;
                D = sums[i - 1, j - 1] + ((word1[i-1] == word2[j-1])? 0: 1);
                sums[i, j] = Math.Min(Math.Min(U, L), D);
            }
        return sums[word1.Length, word2.Length];
    }
}
