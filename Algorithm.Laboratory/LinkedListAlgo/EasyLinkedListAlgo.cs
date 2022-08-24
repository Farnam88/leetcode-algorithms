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
        ListNode prev = null, curren = head;
        while (curren is not null)
        {
            var next = curren.next;
            curren.next = prev;
            prev = curren;
            curren = next;
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
    /// <summary>
    /// 21. Merge Two Sorted Lists
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public ListNode MergeTwoLists2(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode();
        var current = dummy;
        while (list1 is not null || list2 is not null)
        {
            if (list1 is null)
            {
                current.next = list2;
                break;
            }

            if (list2 is null)
            {
                current.next = list1;
                break;
            }
            if (list1.val > list2.val)
            {
                current.next = list2;
                list2 = list2.next;
            }
            else
            {
                current.next = list1;
                list1 = list1.next;
            }
            current = current.next;
        }

        return dummy.next;
    }

    #endregion

    #region + HasCycle

    /// <summary>
    /// 141. Linked List Cycle
    /// https://leetcode.com/problems/linked-list-cycle/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool HasCycle(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
            if (slow == fast)
                return true;
        }


        return false;
    }

    #endregion
}