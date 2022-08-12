using System.Collections;

namespace Algorithm.Tests.LinkedListAlgo;

public class MediumLinkedListAlgoTests
{
    private readonly MediumLinkedListAlgo _sut;

    public MediumLinkedListAlgoTests()
    {
        _sut = new();
    }

    #region + ReorderList

    [Theory]
    [MemberData(nameof(ReorderListData))]
    public void ReorderListTest(ListNode head, ListNode expected)
    {
        _sut.ReorderList(head);

        head.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> ReorderListData =>
        new List<object[]>
        {
            new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))),
                new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(3))))
            },
            new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
                new ListNode(1, new ListNode(5, new ListNode(2, new ListNode(4, new ListNode(3)))))
            }
        };

    #endregion

    #region + RemoveNthFromEndTest

    [Theory]
    [MemberData(nameof(RemoveNthFromEndData))]
    public void RemoveNthFromEndTest(ListNode head, int n, ListNode expected)
    {
        _sut.RemoveNthFromEnd(head, n);

        head.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> RemoveNthFromEndData =>
        new List<object[]>
        {
            new object[]
            {
                new ListNode(1, new ListNode(5, new ListNode(7))),
                1,
                new ListNode(1, new ListNode(5))
            },
            new object[]
            {
                new ListNode(1, new ListNode(2)),
                1,
                new ListNode(1)
            },
            new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
                2,
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(5)))),
            }
        };

    #endregion

    #region + CopyRandomListTest

    [Theory]
    [ClassData(typeof(CopyRandomListData))]
    public void CopyRandomListTest(Node head, Node expected)
    {
        var result = _sut.CopyRandomList(head);

        result.Should().BeEquivalentTo(expected, c => c.IgnoringCyclicReferences());
    }

    #endregion

    #region + AddTwoNumbersTest

    [Theory]
    [MemberData(nameof(AddTwoNumbersData))]
    public void AddTwoNumbersTest(ListNode l1, ListNode l2, ListNode expected)
    {
        var result = _sut.AddTwoNumbers(l1, l2);

        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> AddTwoNumbersData =>
        new List<object[]>
        {
            new object[]
            {
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))),
                new ListNode(7, new ListNode(0, new ListNode(8)))
            },
            new object[]
            {
                new ListNode(0),
                new ListNode(0),
                new ListNode(0)
            },
            new object[]
            {
                new ListNode(9,
                    new ListNode(9,
                        new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
                new ListNode(8,
                    new ListNode(9,
                        new ListNode(9,
                            new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))
            }
        };

    #endregion
}

#region + CopyRandomListData

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

#endregion