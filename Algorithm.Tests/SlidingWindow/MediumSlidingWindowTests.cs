namespace Algorithm.Tests.SlidingWindow;

public class MediumSlidingWindowTests
{
    private readonly MediumSlidingWindow _sut;

    public MediumSlidingWindowTests()
    {
        _sut = new MediumSlidingWindow();
    }

    #region + LengthOfLongestSubstringTest

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("dvdf", 3)]
    [InlineData(" ", 1)]
    public void LengthOfLongestSubstringTest(string s, int expected)
    {
        var result = _sut.LengthOfLongestSubstring(s);

        Assert.Equal(expected, result);
    }

    #endregion

    #region + CharacterReplacementTest

    [Theory]
    [InlineData("ABAB", 2, 4)]
    [InlineData("AABABBA", 1, 4)]
    [InlineData("ABBB", 2, 4)]
    public void CharacterReplacementTest(string s, int k, int expected)
    {
        var result = _sut.CharacterReplacement(s, k);

        Assert.Equal(expected, result);
    }

    #endregion

    #region + CheckInclusionTest

    [Theory]
    [InlineData("ab", "eidbaooo", true)]
    [InlineData("ab", "eidboaoo", false)]
    [InlineData("abc", "ab", false)]
    public void CheckInclusionTest(string s1, string s2, bool expected)
    {
        var result = _sut.CheckInclusion(s1, s2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ab", "eidbaooo", true)]
    [InlineData("ab", "eidboaoo", false)]
    [InlineData("ab", "cabd", true)]
    [InlineData("cd", "accbg", false)]
    public void CheckInclusionTest2(string s1, string s2, bool expected)
    {
        var result = _sut.CheckInclusion2(s1, s2);

        Assert.Equal(expected, result);
    }

    #endregion
}