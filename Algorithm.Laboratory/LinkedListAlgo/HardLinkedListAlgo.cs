namespace Algorithm.Laboratory.LinkedListAlgo;

public class HardLinkedListAlgo
{
    #region + MergeKLists

    /// <summary>
    /// 23. Merge k Sorted Lists
    /// https://leetcode.com/problems/merge-k-sorted-lists/
    /// </summary>
    /// <param name="lists"></param>
    /// <returns></returns>
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists is null || lists.Length == 0)
            return null!;

        while (lists.Length > 1)
        {
            List<ListNode> mergedList = new List<ListNode>();
            for (int i = 0; i < lists.Length; i += 2)
            {
                var l1 = lists[i];
                var l2 = i + 1 < lists.Length ? lists[i + 1] : null!;
                var merged = MergeLists(l1, l2);
                mergedList.Add(merged);
            }

            lists = mergedList.ToArray();
        }

        return lists[0];

        ListNode MergeLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            var tail = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    tail.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    tail.next = l2;
                    l2 = l2.next;
                }

                tail = tail.next;
            }

            if (l1 != null)
                tail.next = l1;
            if (l2 != null)
                tail.next = l2;

            return dummy.next;
        }
    }

    #endregion

    #region + ReverseKGroup

    /// <summary>
    /// 25. Reverse Nodes in k-Group
    /// https://leetcode.com/problems/reverse-nodes-in-k-group/
    /// </summary>
    /// <param name="head"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode dummy = new(0, head);
        var prevPointer = dummy;
        
        while (true)
        {
            var kth = GetKth(prevPointer, k);
            if (kth is null)
                break;
            var nextPointer = kth.next;

            ListNode pre = kth.next, current = prevPointer.next;
            while (current != nextPointer)
            {
                var temp = current.next;
                current.next = pre;
                pre = current;
                current = temp;
            }

            var start = prevPointer.next;
            prevPointer.next = kth;
            prevPointer = start;
        }

        return dummy.next;

        ListNode GetKth(ListNode current, int chunk)
        {
            while (current != null && chunk > 0)
            {
                current = current.next;
                chunk--;
            }

            return current;
        }
    }

    #endregion
}