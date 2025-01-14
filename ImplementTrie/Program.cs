public class Program
{
    public static void Main()
    {
        Trie tr = new Trie();
        tr.Insert("add");
        Console.WriteLine(tr.Search("ad"));
        Console.WriteLine(tr.Search("app"));
        Console.WriteLine(tr.StartsWith("app"));
        tr.Insert("app");
        Console.WriteLine(tr.Search("app"));
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

    public bool Search(string word)
    {
        if (word.Count() == 0)
            return isEnd;
        if (tries.ContainsKey(word[0]))
            return tries[word[0]].Search(word.Remove(0, 1));
        else 
            return false;
    }

    public bool StartsWith(string prefix)
    {
        if (prefix.Count() == 0)
            return true;
        if (tries.ContainsKey(prefix[0]))
            return tries[prefix[0]].StartsWith(prefix.Remove(0, 1));
        else
            return false;
    }
}