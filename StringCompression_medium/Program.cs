

public class Progpam
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.Compress(Console.ReadLine().ToCharArray()));
    }
}

//    aaabbcddddee  qqqqqqqqqqqqe

class Solution
{
    public int Compress(char[] s)
    {
        int idCompressChar = 0;
        int idChar = 0;
        char ch = s[0];
        char[] countSymbols;
        for (int i = 1; i < s.Length; i++) 
        {
            if (ch != s[i]) 
            {
                countSymbols = (i - idChar).ToString().ToCharArray();

                if ((i - idChar) > 1)
                {
                    Array.Copy(countSymbols, 0, s, ++idCompressChar, countSymbols.Length);
                    idCompressChar += countSymbols.Length;
                }
                else
                    idCompressChar++;
                s[idCompressChar] = s[i];
                ch = s[i];
                idChar = i;
            }
        }
        countSymbols = (s.Length - idChar).ToString().ToCharArray();
        if ((s.Length - idChar) > 1)
        {
            Array.Copy(countSymbols, 0, s, ++idCompressChar, countSymbols.Length);
            idCompressChar += countSymbols.Length;
        }
        return idCompressChar;
    }
}