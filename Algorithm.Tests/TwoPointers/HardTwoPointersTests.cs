using Algorithm.Laboratory.TwoPointers;

namespace Algorithm.Tests.TwoPointers;

public class HardTwoPointersTests
{
    private readonly HardTwoPointers _sut;

    public HardTwoPointersTests()
    {
        _sut = new HardTwoPointers();
    }

    #region MyRegion

    [Theory]
    [InlineData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
    [InlineData(new int[] { 4, 2, 0, 3, 2, 5 }, 9)]
    public void TrapTests(int[] height, int expected)
    {
        var result = _sut.Trap(height);
        Assert.Equal(expected, result);
    }

    #endregion
}