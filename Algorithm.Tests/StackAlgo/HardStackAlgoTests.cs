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
    [InlineData(new int[] { 2, 4 }, 2)]
    public void LargestRectangleAreaTest(int[] heights, int expected)
    {
        var result = _sut.LargestRectangleArea(heights);

        Assert.Equal(expected, result);
    }

    #endregion
}