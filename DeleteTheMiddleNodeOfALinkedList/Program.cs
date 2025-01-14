﻿using System.Diagnostics.Tracing;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        ListNode listNode = new ListNode(1);
        listNode.next = new ListNode(2);
        listNode.next.next = new ListNode(3);
        listNode.next.next.next = new ListNode(4);
        listNode.next.next.next.next = new ListNode(5);
        listNode.next.next.next.next.next = new ListNode(6);
        listNode.next.next.next.next.next.next = new ListNode(7);

        var result = solution.DeleteMiddle(listNode);
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
    public ListNode DeleteMiddle(ListNode head)
    {
        if (head.next is null)
        {
            head = null;
            return head;
        }
        ListNode endNode = head.next.next, beforeMiddleNode = head;
        while (endNode is not null && endNode.next is not null)
        {
            beforeMiddleNode = beforeMiddleNode.next;
            endNode = endNode.next.next;
        }
        beforeMiddleNode.next = beforeMiddleNode.next.next;
        return head;
    }
}