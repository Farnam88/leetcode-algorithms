namespace Algorithm.Tests.LinkedListAlgo;

public class EasyLinkedListAlgoTests
{
    private readonly EasyLinkedListAlgo _sut;

    public EasyLinkedListAlgoTests()
    {
        _sut = new();
    }

    #region +

    [Theory]
    [MemberData(nameof(ReverseListData))]
    public void ReverseList(ListNode head, ListNode expected)
    {
        var actual = _sut.ReverseList(head);

        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> ReverseListData =>
        new List<object[]>
        {
            new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))),
                new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))))
            }
        };

    #endregion

    #region + MergeTwoListsTest

    [Theory]
    [MemberData(nameof(MergeTwoListsData))]
    public void MergeTwoListsTest(ListNode list1, ListNode list2, ListNode expected)
    {
        var result = _sut.MergeTwoLists(list1, list2);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(MergeTwoListsData))]
    public void MergeTwoLists2Test(ListNode list1, ListNode list2, ListNode expected)
    {
        var result = _sut.MergeTwoLists2(list1, list2);

        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> MergeTwoListsData =>
        new List<object[]>
        {
            new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(4))),
                new ListNode(1, new ListNode(3, new ListNode(4))),
                new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))))
            },
            new object[]
            {
                null!,
                null!,
                null!
            },
            new object[]
            {
                new ListNode(0, new ListNode(2)),
                new ListNode(-5, new ListNode(0, new ListNode(5))),
                new ListNode(-5, new ListNode(0, new ListNode(0, new ListNode(2, new ListNode(5)))))
            }
        };

    #endregion

    #region + HasCycleTest

    [Theory]
    [ClassData(typeof(HasCycleData))]
    public void HasCycleTest(ListNode head, bool expected)
    {
        var actual = _sut.HasCycle(head);

        Assert.Equal(expected, actual);
    }

    #endregion
}