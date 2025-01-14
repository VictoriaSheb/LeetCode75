



using System.Linq;
using System.Runtime.InteropServices.Marshalling;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8));
    }
}


public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1,
            right = piles.Max();
        int result = right;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            int hours = 0;
            foreach (int pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / (double)middle);
            }

            if (hours < 0) break;

            if (hours <= h)
            {
                result = Math.Min(result, middle);
                Console.WriteLine($"{hours} and {middle}: {result}");
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return result;
    }
}

//public class Solution
//{
//    public int MinEatingSpeed(int[] piles, int h)
//    {
//        Array.Sort(piles);
//        int count = h / piles.Length;
//        int remains = h - count * piles.Length;
//        int result, help = (count == 0) ? 1 : count;
//        result = piles[piles.Count() - 1 - remains] / help + ((piles[piles.Count() - 1 - remains] % help == 0)?0:1);
//        if (remains > 0 && help > 1)
//            result = Math.Max(result, piles[piles.Count() - 1 ] / (help - 1)
//                + ((piles[piles.Count() - 1] % (help - 1) == 0) ? 0 : 1)
//                ); ;
//        help = 0;
//        while (help <= h && result > 0) 
//        {
//            help = CalculateCountH(piles, h, result);
//            result--;
//        }
//        return result + ((help <= h) ?1:2);
//    }

//    public int CalculateCountH(int[] piles, int h, int k) 
//    {
//        int leftBound = -1, newLeftBound;
//        int endCount = piles.Last()/k + ((piles.Last()%k >0)?1:0);
//        int count = 0;
//        int append = piles.First() / k + ((piles.First() % k > 0) ? 1 : 0);
//        for (int i=0; i<endCount; i++)
//        {
//            newLeftBound = BinarySearch(piles, leftBound, k *  append);
//            count += (newLeftBound - leftBound) * (append);
//            leftBound = newLeftBound;
//            if (leftBound + 1 == piles.Length)
//                break;
//            append = piles[leftBound + 1] / k + ((piles[leftBound + 1] % k > 0) ? 1 : 0);
//        }
//        return count;
//    }


//    public int BinarySearch(int[] piles, int left, int k)
//    {
//        left++;
//        int right = piles.Length, pick = left + (right - left) / 2;
//        while (!((pick == (piles.Count() - 1) && piles[pick] <= k) || piles[pick] <= k && piles[pick + 1] > k))
//        {
//            if (piles[pick] > k)
//                right = pick;
//            else
//                left = pick;
//            pick = left + (right - left) / 2;
//            if ((right - left) == 1 && (!((pick == (piles.Count() - 1) && piles[pick] <= k) || piles[pick] <= k && piles[pick + 1] > k)))
//                pick = left = right;
//        }
//        return pick;
//    }

//}