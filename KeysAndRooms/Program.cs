
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.CanVisitAllRooms(null));
    }
}

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        int countVisitRooms = 1;
        bool[] roomsAll = new bool[rooms.Count];
        Queue<int> roomsNow = new Queue<int>();
        roomsNow.Enqueue(0);
        Array.Fill(roomsAll, false);
        roomsAll[0] = true;
        while (roomsNow.Count > 0 && countVisitRooms!=rooms.Count) 
        {
            foreach(int room in rooms[roomsNow.Dequeue()])
            {
                if (!roomsAll[room]) 
                {
                    roomsAll[room] = true;
                    roomsNow.Enqueue(room);
                    countVisitRooms++;
                }
            }
        }
        return (countVisitRooms == rooms.Count);
    }
}