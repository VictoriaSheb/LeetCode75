

public class Progpam 
{
    public static void Main() 
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.ReverseWords(Console.ReadLine()));
    }
}

class Solution 
{
    public string ReverseWords(string s) 
    {
        return String.Join(" ", s.Split(' ').Where(word => word!="").Reverse()).Trim();
    }

}