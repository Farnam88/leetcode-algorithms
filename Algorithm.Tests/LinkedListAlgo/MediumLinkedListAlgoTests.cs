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

    [Theory]
    [InlineData(new int[] { 1, 3, 4, 2, 2 }, 2)]
    [InlineData(new int[] { 3, 1, 3, 4, 2 }, 3)]
    public void FindDuplicateTest(int[] nums, int expected)
    {
        var actual = _sut.FindDuplicate(nums);

        Assert.Equal(expected, actual);
    }

    #endregion
    
    #region + LRUCacheTest

    [Fact]
    public void LruCacheTest()
    {
        LRUCache lRUCache = new LRUCache(2);

        // cache is {1=1}
        lRUCache.Put(1, 1);

        // cache is {1=1, 2=2}
        lRUCache.Put(2, 2);

        // return 1
        var res1 = lRUCache.Get(1);
        Assert.Equal(1, res1);

        // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        lRUCache.Put(3, 3);

        // returns -1 (not found)
        var res2 = lRUCache.Get(2);
        Assert.Equal(-1, res2);

        // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        lRUCache.Put(4, 4);

        // return -1 (not found)
        var res3 = lRUCache.Get(1);
        Assert.Equal(-1, res3);

        // return 3
        var res4 = lRUCache.Get(3);
        Assert.Equal(3, res4);

        // return 4
        var res5 = lRUCache.Get(4);
        Assert.Equal(4, res5);
    }

    #endregion
}