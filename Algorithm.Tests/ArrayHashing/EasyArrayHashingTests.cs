namespace Algorithm.Tests.ArrayHashing;

public class EasyArrayHashingTests
{
    private readonly EasyArrayHashing _sut;

    public EasyArrayHashingTests()
    {
        _sut = new EasyArrayHashing();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, true)]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]
    [InlineData(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void ContainsDuplicateTest(int[] num, bool result)
    {
        var res = _sut.ContainsDuplicate(num);

        Assert.Equal(result, res);
    }

    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("anagram", "nagrm", false)]
    [InlineData("rat", "car", false)]
    public void IsAnagramTest(string s, string t, bool result)
    {
        var res = _sut.IsAnagram(s, t);

        Assert.Equal(result, res);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void TwoSumTest(int[] num, int target, int[] expected)
    {
        var res = _sut.TwoSum(num, target);

        Assert.Equal(expected, res);
    }
}