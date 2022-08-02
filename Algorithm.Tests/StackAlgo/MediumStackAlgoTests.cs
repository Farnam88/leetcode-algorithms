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

    #region + EvalRPNTest

    [Theory]
    [InlineData(new string[] { "18" }, 18)]
    [InlineData(new string[] { "2", "1", "+", "3", "*" }, 9)]
    [InlineData(new string[] { "4", "13", "5", "/", "+" }, 6)]
    [InlineData(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
    public void EvalRPNTest(string[] tokens, int expectd)
    {
        var result = _sut.EvalRPN(tokens);
        Assert.Equal(expectd, result);
    }

    #endregion
}