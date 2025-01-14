

using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution soluton = new Solution();
        int iter = 0;
        while (true) 
        {
            var list = soluton.FindDifference(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(),
                                                     Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            iter++;
        }
    }
}

public class Solution
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    { 
        HashSet<int> nums00 = new HashSet<int>(nums1);
        nums00.RemoveWhere(x => nums2.Contains(x));
        HashSet<int> nums11 = new HashSet<int>(nums2);
        nums11.RemoveWhere(x => nums1.Contains(x));
        return new List<IList<int>>() { nums00.ToList(), nums11.ToList() };
    }
}