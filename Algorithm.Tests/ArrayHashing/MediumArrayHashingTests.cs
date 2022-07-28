using Algorithm.Laboratory.ArrayHashing;

namespace Algorithm.Tests.ArrayHashing;

public class MediumArrayHashingTests
{
    private readonly MediumArrayHashing _sut;

    public MediumArrayHashingTests()
    {
        _sut = new MediumArrayHashing();
    }
    
    #region + GroupAnagramsTest

    [Theory]
    [MemberData(nameof(GroupAnagramsData))]
    public void GroupAnagramsTest(string[] strs, List<List<string>> result)
    {
        var sutResult = _sut.GroupAnagrams(strs);

        long sutSum = 0, resSum = 0;
        foreach (var item in sutResult)
        {
            foreach (var i in item)
            {
                sutSum += i.GetHashCode();
            }
        }

        foreach (var item in result)
        {
            foreach (var i in item)
            {
                resSum += i.GetHashCode();
            }
        }

        Assert.Equal(resSum, sutSum);
    }

    public static IEnumerable<object[]> GroupAnagramsData =>
        new List<object[]>
        {
            new object[]
            {
                new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }, 
                new List<List<string>>
                {
                    new() { "bat" },
                    new() { "nat", "tan" },
                    new() { "ate", "eat", "tea" }
                }
            },
            new object[]
            {
                new string[] { "" },
                new List<List<string>> { new() { "" } }
            },
            new object[]
            {
                new string[] { "a" },
                new List<List<string>> { new() { "a" } }
            }
        };

    #endregion

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2 }, 2, new int[] { 1, 2 })]
    public void TopKFrequentTest(int[] num, int repeat, int[] expected)
    {
        var res = _sut.TopKFrequent(num, repeat);

        Assert.Equal(expected, res);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    public void ProductExceptSelfTest(int[] num, int[] expected)
    {
        var res = _sut.ProductExceptSelf(num);

        Assert.Equal(expected, res);
    }

    #region + IsValidSudokuTest

    [Theory]
    [MemberData(nameof(IsValidSudokuData))]
    public void IsValidSudokuTest(char[][] board, bool isValid)
    {
        var actualResult = _sut.IsValidSudoku(board);

        Assert.Equal(isValid, actualResult);
    }

    public static IEnumerable<object[]> IsValidSudokuData =>
        new List<object[]>
        {
            new object[]
            {
                new char[][]
                {
                    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                },
                true
            },
            new object[]
            {
                new char[][]
                {
                    new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                },
                false
            }
        };

    #endregion

    [Theory]
    [InlineData(new string[] { "lint", "code", "love", "you" }, new string[] { "lint", "code", "love", "you" })]
    [InlineData(new string[] { "Abba", "C#", "Balade", "#C" }, new string[] { "Abba", "C#", "Balade", "#C" })]
    public void EncodeDecodeTest(string[] input, string[] output)
    {
        var encodeResult = _sut.encode(input.ToList());
        var result = _sut.decode(encodeResult);
        Assert.Equal(output, result);
    }

    [Theory]
    [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    public void LongestConsecutiveTest(int[] input, int expectedResult)
    {
        var result = _sut.LongestConsecutive(input);
        Assert.Equal(expectedResult, result);
    }
}