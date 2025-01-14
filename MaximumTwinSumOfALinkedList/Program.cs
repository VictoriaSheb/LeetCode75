using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        ListNode listNode = new ListNode(1);
        listNode.next = new ListNode(2);
        //listNode.next.next = new ListNode(3);
        //listNode.next.next.next = new ListNode(4);
        //listNode.next.next.next.next = new ListNode(5);
        //listNode.next.next.next.next.next = new ListNode(6);
        //  listNode.next.next.next.next.next.next = new ListNode(7);

        Console.WriteLine(solution.PairSum(listNode));
    }
}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public int PairSum(ListNode head)
    {
        ListNode middleHead = head.next, helpHead,  endNode = head.next;
        int maxValue = -1;
        while (endNode.next is not null)
        {
            endNode = endNode.next.next;
            helpHead = middleHead;
            middleHead = middleHead.next;
            helpHead.next = head;
            head = helpHead;
        }
        do
        {
            maxValue = Math.Max(head.val + middleHead.val, maxValue);
            middleHead = middleHead.next;
            head = head.next;
        }while (middleHead is not null) ;
        return maxValue;
    }
}
