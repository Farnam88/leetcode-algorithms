namespace Algorithm.Laboratory.LinkedListAlgo;

public class EasyLinkedListAlgo
{
    #region + ReverseList

    /// <summary>
    /// 206. Reverse Linked List
    /// https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode ReverseList(ListNode head)
    {
        ListNode current = head, prev = default!;
        while (current is not null)
        {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    #region + ListNode class

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    #endregion

    #endregion
}