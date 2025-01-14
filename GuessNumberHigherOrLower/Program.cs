public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.GuessNumber(10));
    }
}

public class Solution //: GuessGame
{
    
    public int GuessNumber(int n)
    {
        int left=1, right=n, pick=(right!=left)?(n/2):left;
        int compare = guess(pick);
        while (compare != 0) 
        {
            if (compare == (-1))
                right = pick;
            else
                left = pick;
            pick = left + (right - left) / 2;
            compare = guess(pick);
            if ((right - left) == 1 && compare == 1)
                pick = left = right;
        }
        return pick;
    }

    public int guess(int num) 
    {
        int value = 5;
        if (num > value)
            return -1;
        if (num < value)
            return 1;
        return 0;
    }
}



