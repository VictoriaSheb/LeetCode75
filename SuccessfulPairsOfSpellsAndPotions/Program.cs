

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var spells = new int[] { 3, 1, 2 };
        var potions = new int[] { 8, 5, 8 };
        Console.WriteLine(solution.SuccessfulPairs(spells, potions, 16));
    }
}





public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        int spellsCount = spells.Count();
        int[] results = new int[spellsCount];
        int left, right, pick;
        long currentSpell, currentStatus;
        for (int i = 0; i < spellsCount; i++) 
        {
            currentSpell = spells[i];
            left = 0;
            right = potions.Length - 1;
            pick = (right != left) ? (right / 2) : left;
            if (potions[right] * currentSpell < success)
                results[i] = 0;
            else
            {
                currentStatus = potions[pick] * currentSpell;
                while (!(currentStatus >= success && (pick == 0 || potions[pick - 1] * currentSpell < success)))
                {
                    if (currentStatus >= success)
                        right = pick;
                    if (currentStatus < success)
                        left = pick;
                    pick = left + (right - left) / 2;
                    currentStatus = potions[pick] * currentSpell;
                    if ((right - left) == 1 && (currentStatus < success))
                        pick = left = right;
                }
                results[i] = potions.Length - pick;
            }
        }
        return results;
    }
}