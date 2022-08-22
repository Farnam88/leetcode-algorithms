namespace Algorithm.Tests.LinkedListAlgo;

public class HardLinkedListAlgoTests
{
    private readonly HardLinkedListAlgo _sut;

    public HardLinkedListAlgoTests()
    {
        _sut = new();
    }

    #region + MergeKListsTest

    [Theory]
    [MemberData(nameof(MergeKListsData))]
    public void MergeKListsTest(ListNode[] lists, ListNode expected)
    {
        var actual = _sut.MergeKLists(lists);

        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> MergeKListsData => new List<object[]>
    {
        new object[]
        {
            new ListNode[]
            {
                new(1, new(4, new(5))),
                new(1, new(3, new(4))),
                new(2, new(6)),
            },
            new ListNode(1, new(1, new(2, new(3, new(4, new(4, new(5, new(6))))))))
        }
    };

    #endregion
}