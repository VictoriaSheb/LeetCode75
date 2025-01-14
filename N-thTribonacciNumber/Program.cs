public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var result = solution.Triboracci(25);
        Console.WriteLine(result);
    }
}

class Solution
{
    public int Triboracci(int n) 
    {
        if(n == 0)
            return 0;
        if(n <= 2)
            return 1;
        n -= 3;
        Queue<int> threes = new Queue<int>();
        threes.Enqueue(0);
        threes.Enqueue(1);
        threes.Enqueue(1);
        while (n > 0)
        {
            threes.Enqueue(threes.Sum());
            threes.Dequeue();
            n--;
        }
        return threes.Sum();
    }
}