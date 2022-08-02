namespace Algorithm.Tests.StackAlgo;

public class MediumStackAlgoTests
{
    private readonly MediumStackAlgo _sut;

    public MediumStackAlgoTests()
    {
        _sut = new MediumStackAlgo();
    }

    [Theory]
    [InlineData(new int[] { -2, 0, -3 }, new int[] { -3, -2 })]
    [InlineData(new int[] { -3, -2, 0 }, new int[] { -3, -3 })]
    [InlineData(new int[] { 3, 5, -1 }, new int[] { -1, 3 })]
    public void MinStackOperationTest(int[] input, int[] expected)
    {
        var result = _sut.MinStackOperation(input);
        Assert.Equal(expected, result);
    }
}