



using System.Linq;
using System.Runtime.InteropServices.Marshalling;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LetterCombinations("7"));
    }
}


public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        int[] nums = digits.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
        char[][] chars = new char[nums.Length][];
        int help, num, count;
        for (int i = 0; i < nums.Length; i++)
        {
            num = nums[i];
            help = (num > 7) ? (97 + (num - 3) * 3 + 4) : (97 + (num - 2) * 3);
            count = (num == 7 || num == 9) ? 4 : 3;
            chars[i] = new char[count];
            for (int j = 0; j < count; j++)
                chars[i][j] = (char)help++;
        }
        char[] combine = new char[chars.Length];
        List<string> strings = new List<string>();
        if (nums.Length > 0)
            for (int zero = 0; zero < chars[0].Length; zero++)
            {
                combine[0] = chars[0][zero];
                if (nums.Length > 1)
                    for (int one = 0; one < chars[1].Length; one++)
                    {
                        combine[1] = chars[1][one];
                        if (nums.Length > 2)
                            for (int two = 0; two < chars[2].Length; two++)
                            {
                                combine[2] = chars[2][two];
                                if (nums.Length > 3)
                                    for (int three = 0; three < chars[3].Length; three++)
                                    {
                                        combine[3] = chars[3][three];
                                        strings.Add(string.Concat(combine));
                                    }
                                else
                                    strings.Add(string.Concat(combine));
                            }
                        else
                            strings.Add(string.Concat(combine));
                    }
                else
                    strings.Add(string.Concat(combine));
            }
        return strings;
    }
}
