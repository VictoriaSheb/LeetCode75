using System.Text.RegularExpressions;

public class Progpam
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.IsSubsequence(Console.ReadLine(), Console.ReadLine()));
    }
}

//  

/*
abs
ahbdfgcser
*/
class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if(s == "")
            return true;
        if(t.Length < s.Length)
            return false;
        Regex regex = new Regex(@"\w*" + string.Join(@"\w*", s.ToArray()) + @"\w*");
        return regex.IsMatch(t);
    }
}