using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.PredictPartyVictory(Console.ReadLine()));
    }
}


public class Solution
{
    public string PredictPartyVictory(string senate)
    {
        LinkedList<char> activeSenators = new LinkedList<char>(senate.ToCharArray());
        Queue<int> blockingSenators = new();
        const char Radiant = 'R';
        int firstBlockingSenator, currentSum;
        LinkedListNode<char>? senator;
        do
        {
            currentSum = 0;
            senator = activeSenators.First;
            while (senator is not null) 
            {
                if (blockingSenators.TryPeek(out firstBlockingSenator) && (firstBlockingSenator != senator.Value))
                {
                    if (senator.Next is null)
                        activeSenators.Remove(senator);                    
                    else
                    {
                        senator = senator.Next;
                        activeSenators.Remove(senator.Previous);
                    }
                    blockingSenators.Dequeue();
                    if (senator.Previous is null && senator.Next is null)
                        senator = null;
                }
                else
                {
                    blockingSenators.Enqueue(senator.Value);
                    currentSum += (blockingSenators.Peek() == Radiant) ? 1 : -1;
                    senator = senator.Next;
                }
            }
        } while (Math.Abs(currentSum) != activeSenators.Count);
        return (activeSenators.First.Value == Radiant) ? "Radiant" : "Dire";
    }
}

//RDRDDRDRDR