



using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.RemoveStars(Console.ReadLine()));
    }
}

public class Solution
{
    public string RemoveStars(string s)
    {
        Stack<char> sb = new Stack<char>();
        int countStars = 0;
        for (int i = (s.Count() -1); i >= 0; i--) 
        {
            if (s[i] == '*')
                countStars++;
            else
            {
                if (countStars == 0)
                    sb.Push(s[i]);
                else
                    countStars--;
            }
        }
        return String.Join("", sb);
    }
}