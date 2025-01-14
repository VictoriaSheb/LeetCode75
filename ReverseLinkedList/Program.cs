using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        ListNode listNode = new ListNode(1);
     //   listNode.next = new ListNode(2);
        //listNode.next.next = new ListNode(3);
        //listNode.next.next.next = new ListNode(4);
        //listNode.next.next.next.next = new ListNode(5);
        //listNode.next.next.next.next.next = new ListNode(6);
        //listNode.next.next.next.next.next.next = new ListNode(7);

        var result = solution.ReverseList(listNode);
        int yyy = 8;
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
    public ListNode ReverseList(ListNode head)
    {
        if (head is null || head.next is null)
            return head;
        ListNode newHead = head.next, noChangePart = head.next.next;
        newHead.next = head;
        head.next = null;
        head = newHead;
        while (noChangePart is not null)
        {
            head = noChangePart;
            noChangePart = noChangePart.next;
            head.next = newHead;
            newHead = head;
        }
        return head;
    }
}
