

using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaxVowels(Console.ReadLine(), int.Parse(Console.ReadLine())));

    }
}

public class Solution
{
    public int MaxVowels(string s, int k)
    {
        string allVowels = "aeiou";
        int countVowelsMax = s.Substring(0, k).Count(ch => allVowels.IndexOf(ch) > 0);
        int countVowelsNow = countVowelsMax;
        
        for (int i=k; i<s.Length;i++)
        {
            if(allVowels.IndexOf(s[i - k]) > 0)
                countVowelsNow--;
            if (allVowels.IndexOf(s[i]) > 0)
                countVowelsNow++;
            if (countVowelsNow > countVowelsMax)
                countVowelsMax = countVowelsNow;        
        }
        return countVowelsMax;
    }
}