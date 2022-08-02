namespace Algorithm.Tests.StackAlgo;

public class EasyStackAlgoTests
{
    private readonly EasyStackAlgo _sut;

    public EasyStackAlgoTests()
    {
        _sut = new EasyStackAlgo();
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("()]", false)]
    [InlineData("({[}])", false)]
    public void IsValid(string s, bool expected)
    {
        var result = _sut.IsValid(s);
        Assert.Equal(expected, result);
    }
}