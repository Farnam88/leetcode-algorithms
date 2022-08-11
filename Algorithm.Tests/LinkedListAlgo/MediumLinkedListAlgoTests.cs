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
}