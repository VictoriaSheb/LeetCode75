

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };


        var maze = new char[][] { new char[] { '+', '+', '.', '+' }, new char[] { '.', '.', '.', '+' }, new char[] { '+', '+', '+', '.' } };
        var entrance = new int[] { 1, 2 };
        var result = solution.NearestExit(maze, entrance);


        Console.WriteLine(result);
    }
}










public class Solution
{
    struct Point 
    {
        public int x;
        public int y;
        public Point(int y, int x) 
        {
            this.x = x;
            this.y = y;
        }
    }

    private int  mX, nY;
    int[][] mazeSteps;
    Queue<Point> points;

    public int NearestExit(char[][] maze, int[] entrance)
    {
        mX = maze[0].Length;
        nY = maze.Length;
      
        mazeSteps = new int[nY][];
        for(int i=0; i < nY; i++) 
        {
            mazeSteps[i] = new int[mX];
            for (int j = 0; j < mX; j++) 
            {
                if (maze[i][j] == '.')
                    mazeSteps[i][j] = int.MaxValue;
                else
                    mazeSteps[i][j] = -1;
            }
        }
        Point point, pointLeft, pointRight, pointUp, pointDown;
        Point start = new Point(entrance[0], entrance[1]);
        mazeSteps[start.y][start.x] = 0;
        points = new Queue<Point>();
        points.Enqueue(start);
        while (points.Count != 0) 
        {
            point = points.Dequeue();
            pointLeft = new Point(point.y, point.x-1);
            pointRight = new Point(point.y, point.x + 1);
            pointUp = new Point(point.y + 1, point.x);
            pointDown = new Point(point.y - 1, point.x);

            SetValueInPoint(pointLeft, point);
            SetValueInPoint(pointRight, point);
            SetValueInPoint(pointUp, point);
            SetValueInPoint(pointDown, point);
        }
        int minSteps = int.MaxValue;
        for (int i = 0; i < nY; i++)
        {
            if (maze[i][0] == '.' && !(i == start.y && start.x == 0))
                minSteps = Math.Min(mazeSteps[i][0], minSteps);
            if (maze[i][mX - 1] == '.' && !(i == start.y && start.x == (mX - 1)))
                minSteps = Math.Min(mazeSteps[i][mX - 1], minSteps);
        }
        for (int i = 1; i < mX - 1; i++)
        {
            if (maze[0][i] == '.' && !(0 == start.y && start.x == i))
                minSteps = Math.Min(mazeSteps[0][i], minSteps);
            if (maze[nY - 1][i] == '.' && !((nY - 1) == start.y && start.x == i))
                minSteps = Math.Min(mazeSteps[nY - 1][i], minSteps);
        }
        if (minSteps == int.MaxValue)
            return -1;
        return minSteps;
    }


    private void SetValueInPoint(Point nearPoint, Point centralPoint) 
    {
        if (CheckExist(nearPoint))
        {
            if (mazeSteps[nearPoint.y][nearPoint.x] == int.MaxValue) 
                points.Enqueue(nearPoint);
            mazeSteps[nearPoint.y][nearPoint.x] = Math.Min(mazeSteps[nearPoint.y][nearPoint.x], mazeSteps[centralPoint.y][centralPoint.x] + 1);
            
        }
    }


    private bool CheckExist(Point point)
    {
        bool result = (point.x >= 0 && point.x < mX && point.y >= 0 && point.y < nY);
        if (result)
            result = mazeSteps[point.y][point.x] != -1;
        return result;
    }
}