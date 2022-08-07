namespace Algorithm.Tests.BinarySearch;

public class MediumBinarySearchTest
{
    private readonly MediumBinarySearch _sut;

    public MediumBinarySearchTest()
    {
        _sut = new MediumBinarySearch();
    }


    #region + SearchMatrixTest

    [Theory]
    [MemberData(nameof(SearchMatrixData))]
    public void SearchMatrix(int[][] matrix, int target, bool expected)
    {
        var result = _sut.SearchMatrix(matrix, target);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> SearchMatrixData =>
        new List<object[]>
        {
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3 },
                },
                2,
                false
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1 },
                },
                1,
                true
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 6 }
                },
                3,
                true
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
                },
                13,
                false
            }
        };

    #endregion

    #region + MinEatingSpeedTest

    [Theory]
    [InlineData(new int[] { 3, 6, 7, 11 }, 8, 4)]
    [InlineData(new int[] { 30, 11, 23, 4, 20 }, 5, 30)]
    [InlineData(new int[] { 30, 11, 23, 4, 20 }, 6, 23)]
    public void MinEatingSpeedTest(int[] piles, int h, int expected)
    {
        var result = _sut.MinEatingSpeed(piles, h);

        Assert.Equal(expected, result);
    }

    #endregion

    #region + SearchTest

    [Theory]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new int[] { 1 }, 0, -1)]
    public void SearchTest(int[] nums, int target, int expected)
    {
        var result = _sut.Search(nums, target);

        Assert.Equal(expected, result);
    }

    #endregion

    #region + FindMinTest

    [Theory]
    [InlineData(new int[] { 3, 4, 5, 1, 2 }, 1)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
    [InlineData(new int[] { 11, 13, 15, 17 }, 11)]
    public void FindMinTest(int[] nums, int expected)
    {
        var result = _sut.FindMin(nums);

        Assert.Equal(result, expected);
    }

    #endregion

    #region + TimeMapTest

    [Fact]
    public void TimeMapTest()
    {
        string[] sequence = new[] { "TimeMap", "set", "get", "get", "set", "get", "get" };
        
        TimeMap timeMap = new TimeMap();

        // store the key "foo" and value "bar" along with timestamp = 1.
        timeMap.Set("foo", "bar", 1);

        // return "bar"
        var result1 = timeMap.Get("foo", 1);

        // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        var result2 = timeMap.Get("foo",
            3);

        // store the key "foo" and value "bar2" along with timestamp = 4.
        timeMap.Set("foo", "bar2", 4);

        // return "bar2"
        var result3 = timeMap.Get("foo", 4);

        // return "bar2"
        var result4 = timeMap.Get("foo", 5);
        
        Assert.Equal("bar", result1);
        Assert.Equal("bar", result2);
        Assert.Equal("bar2", result3);
        Assert.Equal("bar2", result4);
    }

    #endregion
}