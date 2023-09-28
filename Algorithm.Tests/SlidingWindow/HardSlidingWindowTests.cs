namespace Algorithm.Tests.SlidingWindow;

public class HardSlidingWindowTests
{
    private readonly HardSlidingWindow _sut;

    public HardSlidingWindowTests()
    {
        _sut = new HardSlidingWindow();
    }

    #region + MinWindowTest

    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    [InlineData("ab", "a", "a")]
    [InlineData("ab", "b", "b")]
    [InlineData("dfghabaca", "aaa", "abaca")]
    public void MinWindowTest(string s, string t, string expected)
    {
        var result = _sut.MinWindow(s, t);

        Assert.Equal(expected, result);
    }

    #endregion

    #region + MaxSlidingWindowTest

    [Theory]
    [InlineData(new int[] {1, 3, -1, -3, 5, 3, 6, 7}, 3, new int[] {3, 3, 5, 5, 6, 7})]
    [InlineData(new int[] {1}, 1, new int[] {1})]
    [InlineData(new int[] {1, -1}, 1, new int[] {1, -1})]
    [InlineData(new int[] {9, 11}, 2, new int[] {11})]
    [InlineData(new int[] {2, 5, 3, 1, 7, 9}, 2, new int[] {5, 5, 3, 7, 9})]
    [InlineData(new int[] {1, 3, 1, 2, 0, 5}, 3, new int[] {3, 3, 2, 5})]
    [InlineData(new int[] {8, 7, 6, 9}, 2, new int[] {8, 7, 9})]
    public void MaxSlidingWindowTest(int[] nums, int k, int[] expected)
    {
        var result = _sut.MaxSlidingWindow(nums, k);

        Assert.Equal(expected, result);
    }

    #endregion
}