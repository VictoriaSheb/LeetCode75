
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.GcdOfStrings(Console.ReadLine(), Console.ReadLine()));

    }
}

public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        string minStr = (str1.Length < str2.Length)?str1:str2;
        string maxStr = (str2 == minStr) ? str1 : str2;
        string partMin;
        int lengthPart;
        bool result;
        for(int j=1; j<= minStr.Length; j++)
        {
            if (((minStr.Length % (double)j) == 0) && ((maxStr.Length % (double)(minStr.Length / j)) == 0)) 
            {
                lengthPart = minStr.Length / j;
                partMin = minStr.Substring(0, lengthPart);
                result = true;
                for (int i = 1; i < j; i++) 
                {
                    result &= partMin == minStr.Substring(lengthPart * i, lengthPart);
                }
                if(result)
                    for (int i = 1; i <= (maxStr.Length / (double)(lengthPart)); i++)
                    {
                        result &= (partMin == maxStr.Substring(lengthPart * (i - 1), lengthPart));
                    }
                if (result)
                    return partMin;
            }            
        }
        return "";
    }
}