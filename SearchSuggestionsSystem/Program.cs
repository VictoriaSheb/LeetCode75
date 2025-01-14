public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        var result = solution.SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");
        Console.WriteLine(result);
    }
}

public class Solution
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var root = new Trie();
        foreach (var product in products) 
        {
            root.Insert(product);
        }

        var results = new List<IList<string>>();
        var currentWord = "";
        for (int i = 0; i < searchWord.Length; i++) 
        {
            if (root == null)
            {
                results.Add(new List<string>());
                continue;
            }
            root = root.Search(searchWord[i]);
            if (root == null)
                results.Add(new List<string>());
            else
            {
                currentWord += searchWord[i];
                results.Add(root.GetSearchBy(new List<string>(), currentWord));
            }            
        }
        return results;
    }
}

public class Trie
{
    private Dictionary<char, Trie> tries;
    private bool isEnd = false;

    public Trie()
    {
        tries = new Dictionary<char, Trie>();
    }

    public void Insert(string word)
    {
        if (word.Count() == 0)
        {
            isEnd = true;
            return;
        }
        if (!tries.ContainsKey(word[0]))
            tries.Add(word[0], new Trie());

        tries[word[0]].Insert(word.Remove(0, 1));
    }

    public List<string> GetSearchBy(List<string> results, string currentWord) 
    {
        if (results.Count == 3)
            return results;
        if (isEnd)
            results.Add(currentWord);
        foreach (var triePair in tries.OrderBy(x => x.Key)) 
        {
            results = triePair.Value.GetSearchBy(results, currentWord + triePair.Key);
            if (results.Count == 3)
                return results;
        }
        return results;
    }

    public Trie? Search(char ch)
    {
        if (tries.ContainsKey(ch))
            return tries[ch];
        else
            return null;
    }
}