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
    public void MinWindowTest(string s, string t, string expected)
    {
        var result = _sut.MinWindow(s, t);

        Assert.Equal(expected, result);
    }

    #endregion
}