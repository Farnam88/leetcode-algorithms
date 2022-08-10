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

    #endregion

    #region + MergeTwoLists

    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null)
            return list2;
        if (list2 is null)
            return list1;

        if (list1.val > list2.val)
        {
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
        else
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }
    }

    #endregion
}