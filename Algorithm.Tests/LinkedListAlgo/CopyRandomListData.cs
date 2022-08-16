using System.Collections;
using Microsoft.VisualBasic;

namespace Algorithm.Tests.LinkedListAlgo;

public class CopyRandomListData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        Node node1 = new(7), node2 = new(13), node3 = new(11), node4 = new Node(10), node5 = new Node(1);
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;
        node1.random = null!;
        node2.random = node1;
        node3.random = node5;
        node4.random = node3;
        node5.random = node1;
        yield return new object[] { node1, node1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class HasCycleData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        ListNode node1 = new(3), node2 = new(2), node3 = new(0), node4 = new(-4);
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node2;
        yield return new object[] { node1, true };
        ListNode node5 = new(1), node6 = new(2);
        node5.next = node6;
        node6.next = node5;
        yield return new object[] { node5, true };
        ListNode node7 = new(1);
        yield return new object[] { node7, false };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}