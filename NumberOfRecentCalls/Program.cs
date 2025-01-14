using System.Text;

public class Program
{
    public static void Main()
    {
        RecentCounter solution = new RecentCounter();
        while(true)
            Console.WriteLine(solution.Ping(int.Parse(Console.ReadLine())));

    }
}


public class RecentCounter
{
    Queue<int> calls;
    int startBorder;
    int integerNb;
    int lowerOrder;
    bool bigOther;

    public RecentCounter() 
    {
        calls = new Queue<int>();
        lowerOrder = 0;
        integerNb = 0;
        bigOther = false;
    }
    public int Ping(long t)
    {
        
        if (integerNb < (t / 3000))
        {
            while (lowerOrder > 0)
            {
                calls.Dequeue();
                lowerOrder--;
            }
            lowerOrder = calls.Count;
            bigOther = (t / 3000) > (integerNb + 1);
            integerNb = (int)(t / 3000);
        }
        startBorder = (int)(t - integerNb*3000);
        calls.Enqueue(startBorder);
        while (lowerOrder > 0 && (bigOther || calls.Peek() < startBorder))
        { 
            calls.Dequeue();
            lowerOrder--;
        }
        return calls.Count;
    }
}








