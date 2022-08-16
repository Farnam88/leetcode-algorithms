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

    #region + FindDuplicateTest

    public int FindDuplicateTest(int[] nums)
    {
        return 0;
    }

    #endregion
}