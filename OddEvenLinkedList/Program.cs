using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        ListNode listNode = new ListNode(1);
        listNode.next = new ListNode(2);
        listNode.next.next = new ListNode(3);
        //listNode.next.next.next = new ListNode(4);
        //listNode.next.next.next.next = new ListNode(5);
        //listNode.next.next.next.next.next = new ListNode(6);
        //listNode.next.next.next.next.next.next = new ListNode(7);

        var result = solution.OddEvenList(listNode);
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
    public ListNode OddEvenList(ListNode head)
    {
        if (head is null || head.next is null || head.next.next is null)
            return head;
        ListNode oddNodes = head, evenHead = head.next, evenNodes = head.next;
        oddNodes.next = evenNodes.next;
        oddNodes = oddNodes.next;
        while (oddNodes.next is not null && oddNodes.next.next is not null)
        {
            evenNodes.next = oddNodes.next;
            evenNodes = evenNodes.next;
            oddNodes.next = evenNodes.next;
            oddNodes = oddNodes.next;
        }
        if (oddNodes.next is not null)

            evenNodes.next = oddNodes.next;
        else
            evenNodes.next = null;
        oddNodes.next = evenHead;
        return head;
    }
}
