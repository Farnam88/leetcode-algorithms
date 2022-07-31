namespace Algorithm.Tests.TwoPointers;

public class EasyTwoPointersTests
{
    private readonly EasyTwoPointers _sut;

    public EasyTwoPointersTests()
    {
        _sut = new EasyTwoPointers();
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("!!!!abcddcba&&%%#@!@#$", true)]
    [InlineData(",.", true)]
    public void IsPalindromeTest(string str, bool expectedResult)
    {
        var result = _sut.IsPalindrome(str);
        Assert.Equal(expectedResult, result);
    }
}