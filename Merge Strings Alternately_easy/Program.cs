

using System.Text;

public class Program
{
    public static void Main()     
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MergeAlternately(Console.ReadLine(), Console.ReadLine()));

    }
}

public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        int maxChars = Math.Max(word1.Length, word2.Length);
        StringBuilder sbl = new StringBuilder(maxChars*2);
        for (int i = 0; i < maxChars; i++) 
        {
            if (i < word1.Length)
                sbl.Append(word1[i]);
            if (i < word2.Length)
                sbl.Append(word2[i]);
        }
        return sbl.ToString();
    }
}