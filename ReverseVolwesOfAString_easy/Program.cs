using System.Text;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.ReverseVowels(Console.ReadLine()));

    }
}

public class Solution
{
    public string ReverseVowels(string s)
    {
        string allVowels = "aeiouAEIOU";
        char[] vowels  = s.Where(ch => allVowels.IndexOf(ch) >= 0).Reverse().ToArray();
        StringBuilder stringBuilder= new StringBuilder(s);
        int iter = 0;
        for (int i = 0; i < vowels.Length; i++) 
        {
            while (allVowels.IndexOf(s[iter]) < 0) 
            {
                iter++;
            }
            stringBuilder[iter] = vowels[i];
            iter++;
        }
        return stringBuilder.ToString();
    }
}