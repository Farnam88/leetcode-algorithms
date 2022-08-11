namespace Algorithm.Laboratory.LinkedListAlgo;

public class MediumLinkedListAlgo
{
    #region + ReorderList

    /// <summary>
    /// 143. Reorder List
    /// https://leetcode.com/problems/reorder-list/
    /// </summary>
    /// <param name="head"></param>
    public void ReorderList(ListNode head)
    {
        ListNode slow = head, fast = head.next;

        while (slow != null! && fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode rightPortion = slow!.next, prev = null!;
        slow!.next = null;

        while (rightPortion != null)
        {
            var temp = rightPortion.next;
            rightPortion.next = prev;
            prev = rightPortion;
            rightPortion = temp;
        }

        ListNode leftPortion = head;
        rightPortion = prev;

        while (rightPortion != null)
        {
            ListNode tempL = leftPortion.next, tempR = rightPortion.next;
            leftPortion.next = rightPortion;
            rightPortion.next = tempL;
            rightPortion = tempR;
            leftPortion = tempL;
        }
    }

    #endregion

    #region MyRegion

    /// <summary>
    /// 19. Remove Nth Node From End of List
    /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new (0, head), left = dummy, right = head;

        while (n > 0 && right != null!)
        {
            right = right.next;
            n--;
        }

        while (right != null)
        {
            left = left.next;
            right = right.next;
        }

        left.next = left?.next.next;

        return dummy.next;
    }

    #endregion
}