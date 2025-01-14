
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        //var connections = new int[][] { new int[]{ 0, 1 }, new int[] { 1, 3 },
        //                               new int[]{2, 3 }, new int[]{4, 0}, new int[]{4, 5 } };

        IList<IList<string>> equations = new List<IList<string>>() { new List<string>() { "a", "b" }, new List<string>() { "b", "c" } };
        double[] values = new double[] { 2.0, 3.0};
        IList<IList<string>> queries = new List<IList<string>>() { new List<string>() { "a", "c" }, new List<string>() { "b", "a" }, new List<string>() { "a", "e" }, new List<string>() { "a", "a" }, new List<string>() { "x", "x" } };

        var result = solution.CalcEquation(equations, values, queries);


        Console.WriteLine("   ");
    }
}


public class Solution
{
    Dictionary<string, List<(string name, double factor)>> names;
    double[] valuesQueries;
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        names = new Dictionary<string, List<(string, double)>>();
        (string, double) tipleHelp;
        for (int i = 0; i<values.Count();i++)
        {
            if (equations[i][0] == equations[i][1])
                continue;
            names[equations[i][0]] = names.GetValueOrDefault(equations[i][0], new List<(string, double)>());
            names[equations[i][1]] = names.GetValueOrDefault(equations[i][1], new List<(string, double)>());

            tipleHelp = (equations[i][1], values[i]);
            names[equations[i][0]].Add(tipleHelp);

            tipleHelp = (equations[i][0], 1.0/values[i]);
            names[equations[i][1]].Add(tipleHelp);
        }
        valuesQueries = new double[queries.Count];
        for (int i = 0; i < queries.Count(); i++) 
        {
            if (!names.ContainsKey(queries[i][0]) || !names.ContainsKey(queries[i][1]))
                valuesQueries[i] = -1;
            else if (queries[i][0] == queries[i][1])
                valuesQueries[i] = 1;
            else
                valuesQueries[i] = FillQueries(queries[i][0], queries[i][1], new HashSet<string>() { queries[i][0] });
        }
        return valuesQueries;
    }

    private double FillQueries(string numerator, string denominator, HashSet<string> pathNodes) 
    {
        double factor;
        foreach(var denominatorNow in names[numerator]) 
        {
            if (denominatorNow.name == denominator)
            {
                return denominatorNow.factor;
            }
            else 
            {
                if (pathNodes.Contains(denominatorNow.name))
                    continue;
                pathNodes.Add(denominatorNow.name);
                factor = FillQueries(denominatorNow.name, denominator, pathNodes);
                if(factor >= 0)
                    return factor*denominatorNow.factor;
            }  
        }
        return -1;
    }
}

//public class Solution
//{
//    int errors;
//    Dictionary<int, List<int>> keyValuePairs;
//    bool[] peeks;
//    public int MinReorder(int n, int[][] connections)
//    {
//        keyValuePairs = new Dictionary<int, List<int>>();
//        for (int i = 0; i < connections.Length; i++)
//        {
//            keyValuePairs[connections[i][0]] = keyValuePairs.GetValueOrDefault(connections[i][0], new List<int>());
//            keyValuePairs[connections[i][0]].Add(-connections[i][1]);

//            keyValuePairs[connections[i][1]] = keyValuePairs.GetValueOrDefault(connections[i][1], new List<int>());
//            keyValuePairs[connections[i][1]].Add(connections[i][0]);
//        }
//        errors = 0;
//        peeks = new bool[n];
//        Array.Fill(peeks, false);
//        peeks[0] = true;
//        SearchAllErrors(0);
//        return errors;
//    }

//    private void SearchAllErrors(int peek)
//    {
//        foreach (var lastPeek in keyValuePairs[peek])
//        {
//            if (!peeks[Math.Abs(lastPeek)])
//            {

//                if (lastPeek < 0)
//                {
//                    peeks[-lastPeek] = true;
//                    errors++;
//                    SearchAllErrors(-lastPeek);
//                }
//                else
//                {
//                    peeks[lastPeek] = true;
//                    SearchAllErrors(lastPeek);
//                }
//            }
//        }
//    }
//}