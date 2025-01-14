

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };


        var maze = new int[][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } };
        var result = solution.OrangesRotting(maze);


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

    private int nX, mY;

    public int OrangesRotting(int[][] grid)
    {
        nX = grid[0].Length;
        mY = grid.Length;
        int countFreshOranges = 0;
        int idIteration = 0;
        Queue<Point> rottenOranges = new Queue<Point>();
        for (int y = 0; y < mY; y++)
            for (int x = 0; x < nX; x++)
            {
                if (grid[y][x] == 2)
                    rottenOranges.Enqueue(new Point(y, x));
                else if (grid[y][x] == 1)
                    countFreshOranges++;

            }
        Point point, pointLeft, pointRight, pointUp, pointDown;
        int countRottenOranges;
        while (countFreshOranges > 0 && rottenOranges.Count > 0)
        {
            countRottenOranges = rottenOranges.Count;
            while (countRottenOranges != 0)
            {
                point = rottenOranges.Dequeue();
                pointLeft = new Point(point.y, point.x - 1);
                pointRight = new Point(point.y, point.x + 1);
                pointUp = new Point(point.y + 1, point.x);
                pointDown = new Point(point.y - 1, point.x);

                if (CheckExist(pointLeft) && grid[pointLeft.y][pointLeft.x] == 1)
                {
                    rottenOranges.Enqueue(pointLeft);
                    countFreshOranges--;
                    grid[pointLeft.y][pointLeft.x] = 2;
                }
                if (CheckExist(pointRight) && grid[pointRight.y][pointRight.x] == 1)
                {
                    rottenOranges.Enqueue(pointRight);
                    countFreshOranges--;
                    grid[pointRight.y][pointRight.x] = 2;
                }
                if (CheckExist(pointUp) && grid[pointUp.y][pointUp.x] == 1)
                {
                    rottenOranges.Enqueue(pointUp);
                    countFreshOranges--;
                    grid[pointUp.y][pointUp.x] = 2;
                }
                if (CheckExist(pointDown) && grid[pointDown.y][pointDown.x] == 1)
                {
                    rottenOranges.Enqueue(pointDown);
                    countFreshOranges--;
                    grid[pointDown.y][pointDown.x] = 2;
                }
                countRottenOranges--;
            }
            idIteration++;
        }
        return (countFreshOranges == 0) ? idIteration : (-1);
    }

    private bool CheckExist(Point point)
    {
        return (point.x >= 0 && point.x < nX && point.y >= 0 && point.y < mY);
    }
}


/*
 
 int[] x = { 0, 0, 1, -1};
 int[] y = { 1, -1, 0, 0 };
 
 */