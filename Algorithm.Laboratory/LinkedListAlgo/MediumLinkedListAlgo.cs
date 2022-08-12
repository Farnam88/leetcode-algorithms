using System.Text;

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

    #region + RemoveNthFromEnd

    /// <summary>
    /// 19. Remove Nth Node From End of List
    /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    /// </summary>
    /// <param name="head"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head), left = dummy, right = head;

        while (n > 0 && right != null)
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

    #region + CopyRandomList

    /// <summary>
    /// 138. Copy List with Random Pointer
    /// https://leetcode.com/problems/copy-list-with-random-pointer/
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public Node CopyRandomList(Node head)
    {
        if (head is null)
            return null;
        Dictionary<Node, Node> mapping = new();
        Node current = head;

        while (current is not null)
        {
            mapping.TryAdd(current, null);
            mapping[current] = new Node(current.val);
            current = current.next;
        }

        current = head;
        while (current is not null)
        {
            var next = current.next;
            var random = current.random;
            var copyOfCurrent = mapping[current];
            copyOfCurrent.next = next != null ? mapping[next] : null;
            copyOfCurrent.random = random != null ? mapping[random] : null;
        }

        return mapping[head];
    }

    #endregion

    #region + AddTwoNumbers

    /// <summary>
    /// 2. Add Two Numbers
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode();
        var pointer = dummy;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0)
        {
            int first = l1?.val ?? 0;
            int second = l2?.val ?? 0;

            var val = first + second + carry;
            carry = val / 10;
            val %= 10;
            pointer.next = new ListNode(val);
            pointer = pointer.next;
            l1 = l1 != null ? l1.next : null;
            l2 = l2 != null ? l2.next : null;
        }

        return dummy.next;
    }

    #endregion
}