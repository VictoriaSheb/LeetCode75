

using System;

public class Program
{
    public static void Main()
    {
        SmallestInfiniteSet obj = new SmallestInfiniteSet();
        //int param_1 = obj.PopSmallest();
        //obj.AddBack(2);
        Console.WriteLine(obj.PopSmallest());
        Console.WriteLine(obj.PopSmallest());
        Console.WriteLine(obj.PopSmallest());
    }
}


public class SmallestInfiniteSet
{
    int[] allNums;

    public SmallestInfiniteSet()
    {
        allNums = new int[1000];
        for(int i=0;i<1000; i++)
            allNums[i] = i+1; 
    }

    public int PopSmallest()
    {
        int startSearch = 0;
        if(allNums[startSearch] == -1)
            while (allNums[startSearch] == -1) { startSearch++; }
        allNums[startSearch] = -1;
        return startSearch+1;
    }

    public void AddBack(int num)
    {
        if (allNums[num-1] == -1)
            allNums[num-1] = num;
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */