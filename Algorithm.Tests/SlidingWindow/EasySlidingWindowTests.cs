namespace Algorithm.Tests.SlidingWindow;

public class EasySlidingWindowTests
{
    private readonly EasySlidingWindow _sut;

    public EasySlidingWindowTests()
    {
        _sut = new EasySlidingWindow();
    }

    #region + MaxProfit

    [Theory]
    [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    [InlineData(new int[] { 1, 4, 2 }, 3)]
    [InlineData(new int[] { 1, 2 }, 1)]
    [InlineData(new int[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0, 9 }, 9)]
    public void MaxProfitTest(int[] prices, int expected)
    {
        var result = _sut.MaxProfit(prices);

        Assert.Equal(expected, result);
    }

    #endregion
}