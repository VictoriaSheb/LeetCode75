


using System.Text;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(string.Join(" ", solution.AsteroidCollision(Console.ReadLine().Split(" ").Select(int.Parse).ToArray())));

    }
}


public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> idsResult = new Stack<int>();
        for (int i = 0; i < asteroids.Count(); i++)
        {
            if ((idsResult.Count() > 0) && (asteroids[i] < 0) && (asteroids[idsResult.Peek()]> 0))
            {
                while (idsResult.Count() > 0 && (asteroids[idsResult.Peek()] > 0) && (asteroids[idsResult.Peek()] < (-asteroids[i])))
                    idsResult.Pop();
                if ((idsResult.Count() == 0) || (asteroids[idsResult.Peek()] < 0))
                    idsResult.Push(i);
                else if(asteroids[idsResult.Peek()] == (-asteroids[i]))
                    idsResult.Pop();

            }
            else
                idsResult.Push(i);
        }
        return asteroids.Where((x, i) => (idsResult.Count > 0) ? idsResult.Contains(i) : false).ToArray();
    }
}