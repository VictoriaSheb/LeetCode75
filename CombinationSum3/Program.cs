

public class Program 
{
    public static void Main() 
    {
        Solution solution = new Solution();
        var result = solution.CombinationSum3(4, 24);
        Console.WriteLine(result);
    }
}



public class Solution
{

    public IList<IList<int>> CombinationSum3(int k, int n)
    {

        IList<IList<int>> list = new List<IList<int>>();
        List<int> l = new List<int>();

        Combination(list, l, n, 1, k);

        return list;
    }
    // n representa la suma
    // index representa el utlimo numero agregado
    // k representa la cantidad de elementos total
    private void Combination(IList<IList<int>> list, List<int> l, int n, int index, int k)
    {

        if (k == 0 && n == 0)
        {
            list.Add(new List<int>(l));
        }
        if (n < 0 || k == 0) return;

        for (int i = index; i < 10; i++)
        {
            l.Add(i);
            Combination(list, l, n - i, i + 1, k - 1);
            l.RemoveAt(l.Count - 1);
        }
    }
}

//class Solution 
//{
//    public IList<IList<int>> CombinationSum3(int k, int n) 
//    {
//        int[] prototype = new int[k];
//        int append = 1;
//        for (int i = 0; i < k; i++) 
//        {
//            prototype[i] = i+ append;
//        }
//        List<IList<int>> results = new List<IList<int>>();
//        prototype = SetMaxCase(prototype, n);
//        string hash = "";
//        if (prototype is not null)
//            hash = string.Join(" ", prototype);
//        HashSet<string> existVariants = new HashSet<string>();
//        while (prototype is not null) 
//        {
//            if (!existVariants.Contains(hash))
//            {
//                results.Add(new List<int>(prototype));
//                existVariants.Add(hash);
//                Fill(results, new List<int>(prototype), existVariants);
//            }
//            append++;
//            for (int i = 0; i < k; i++)
//            {
//                prototype[i] = i + append;
//            }
//            prototype = SetMaxCase(prototype, n);
//            if(prototype is not null)
//                hash = string.Join(" ", prototype);
//        }
//        return results;
//    }

//    private int[] SetMaxCase(int[] prototype, int n) 
//    {
//        if (prototype.Last() > 9)
//            return null;
//        int sum = 0;
//        for (int i = 0; i < prototype.Length; i++)
//            sum += prototype[i];
//        if (sum > n)
//            return null;
//        if(sum == n)
//            return prototype;
//        int appendSum = n - sum, difference, maxNumber = 9;
//        int iter = prototype.Length - 1;
//        while (appendSum != 0 && iter>=0) 
//        {
//            difference = maxNumber - prototype[iter];
//            if (appendSum <= difference)
//            {
//                prototype[iter] += appendSum;
//                appendSum = 0;
//            }
//            else
//            {
//                appendSum -= difference;
//                prototype[iter] += difference;
//                maxNumber--;
//                iter--;
//            }
//        }
//        if (appendSum != 0)
//            return null;
//        else 
//            return prototype;
//    }

//    private void Fill(IList<IList<int>> result, List<int> prototype, HashSet<string> existVariants) 
//    {
//        List<int> newPrototype = new List<int>(prototype);
//        string hash;
//        List<int> idICanGive = new List<int>();
//        for (int i = prototype.Count - 1; i > 0; i--) 
//        {
//            if (prototype[i] - prototype[i - 1] > 2)
//            {
//                newPrototype[i]--;
//                newPrototype[i - 1]++;
//                hash = string.Join(" ", newPrototype);
//                if (!existVariants.Contains(hash))
//                {
//                    result.Add(newPrototype);
//                    existVariants.Add(hash);
//                    Fill(result, newPrototype, existVariants);
//                }
//                newPrototype = new List<int>(prototype);
//            }
//            else if (prototype[i] - prototype[i - 1] == 2) 
//            {
//                if (idICanGive.Count > 0)
//                    foreach (var id in idICanGive)
//                    {
//                        newPrototype[id]--;
//                        newPrototype[i - 1]++;
//                        hash = string.Join(" ", newPrototype);
//                        if (!existVariants.Contains(hash))
//                        {
//                            result.Add(newPrototype);
//                            existVariants.Add(hash);
//                            Fill(result, newPrototype, existVariants);
//                        }
//                        newPrototype = new List<int>(prototype);
//                    }
//                idICanGive.Add(i);
//            }
//        }
//    }
//}