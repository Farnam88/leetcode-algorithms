namespace Algorithm.Tests.StackAlgo;

public class HardStackAlgoTests
{
    private readonly HardStackAlgo _sut;

    public HardStackAlgoTests()
    {
        _sut = new HardStackAlgo();
    }

    #region + LargestRectangleAreaTest

    [Theory]
    [InlineData(new int[] { 2, 1, 5, 6, 2, 3 }, 10)]
    [InlineData(new int[] { 2, 4 }, 4)]
    [InlineData(new int[] { 1, 1 }, 2)]
    [InlineData(new int[] { 1, 2, 8, 3 }, 8)]
    [InlineData(new int[] { 999, 999, 999, 999 }, 3996)]
    public void LargestRectangleAreaTest(int[] heights, int expected)
    {
        var result = _sut.LargestRectangleArea(heights);

        Assert.Equal(expected, result);
    }

    #endregion
}