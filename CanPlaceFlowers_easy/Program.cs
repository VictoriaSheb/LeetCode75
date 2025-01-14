public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.CanPlaceFlowers(Console.ReadLine().Split(" ").Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));

    }
}

public class Solution
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n == 0)
            return true;
        bool isPlant = true;
        for (int i = 0; i < flowerbed.Length; i++) 
        {
            if (flowerbed[i] == 1)
                i++;
            else
            {
                if ((i + 1) < flowerbed.Length)
                    isPlant &= flowerbed[i + 1] == 0;
                if (isPlant)
                {
                    if(--n == 0)
                        return true;
                }
                else
                    i++;
                i++;
            }
            isPlant = true;
        }
        return false;
    }
}