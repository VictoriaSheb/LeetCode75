public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };

        var one = new int[] { 2, 2, 2, 2, 2, 2, 1, 4, 5, 5, 5, 5, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        Console.WriteLine(solution.TotalCost(one, 7, 3));
    }
}


public class Solution
{
    struct Cost : IComparable<Cost>
    {
        public int value;
        public int id;
        public Cost(int value, int id) 
        {
            this.id = id;
            this.value = value;
        }

        public int CompareTo(Cost other)
        {
            if (value < other.value) return -1;
            if (value > other.value) return 1;

            if (id < other.id) return -1;
            if (id > other.id) return 1;

            return 0;
        }
    }


    public long TotalCost(int[] costs, int k, int candidates)
    {
        PriorityQueue<int, Cost> showCandidates = new PriorityQueue<int, Cost>();
        int len = costs.Length;
        int idLeft = candidates - 1, idRight = len - candidates;
        long sum = 0;
        int idCandidate, id;
        bool added = (idLeft < idRight);
        if (!added)
            for (int i = 0; i < len; i++)
                showCandidates.Enqueue(i, new Cost(costs[i], i));
        else 
        {
            for (int i = 0; i < candidates; i++)
            { 
                showCandidates.Enqueue(i, new Cost(costs[i], i));
                id = len - i - 1;
                showCandidates.Enqueue(id, new Cost(costs[id], id));
            }
        }
        while(k>0)
        {
            idCandidate = showCandidates.Dequeue();
            if (added)
            {
                if (idCandidate <= idLeft)
                    id = ++idLeft;
                else
                    id = --idRight;
                added = (idLeft < idRight);
                if (added)
                    showCandidates.Enqueue(id, new Cost(costs[id], id));
            }
            sum += costs[idCandidate];
            k--;
        }
        return sum;
    }
}
