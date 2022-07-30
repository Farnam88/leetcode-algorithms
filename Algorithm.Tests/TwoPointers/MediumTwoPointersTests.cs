using Algorithm.Laboratory.TwoPointers;

namespace Algorithm.Tests.TwoPointers;

public class MediumTwoPointersTests
{
    private readonly MediumTwoPointers _sut;

    public MediumTwoPointersTests()
    {
        _sut = new MediumTwoPointers();
    }

    #region + TwoSumTest

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 3, 4 }, 6, new int[] { 1, 3 })]
    [InlineData(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
    public void TwoSumTest(int[] numbers, int target, int[] expectedResult)
    {
        var result = _sut.TwoSum(numbers, target);

        Assert.Equal(result, expectedResult);
    }

    #endregion

    #region + ThreeSumTest

    [Theory]
    [MemberData(nameof(ThreeSumData))]
    public void ThreeSumTest(int[] numbers, List<List<int>> expectedResult)
    {
        var result = _sut.ThreeSum(numbers);
        long expectedSum = 0, resSum = 0;
        foreach (var item in expectedResult)
        {
            foreach (var i in item)
            {
                expectedSum += i.GetHashCode();
            }
        }

        foreach (var item in result)
        {
            foreach (var i in item)
            {
                resSum += i.GetHashCode();
            }
        }

        Assert.Equal(expectedSum, resSum);
        Assert.Equal(expectedResult.Count, result.Count);
    }

    public static IEnumerable<object[]> ThreeSumData =>
        new List<object[]>
        {
            new object[]
            {
                new int[] { -1, 0, 1, 2, -1, -4 },
                new List<List<int>>
                {
                    new() { -1, -1, 2 },
                    new() { -1, 0, 1 }
                }
            },
            new object[]
            {
                new int[] { 0, 1, 1 },
                new List<List<int>>()
            },
            new object[]
            {
                new int[] { 0, 0, 0 },
                new List<List<int>>
                {
                    new()
                    {
                        0, 0, 0
                    }
                }
            },
            new object[]
            {
                new int[] { -2, 0, 0, 2, 2 },
                new List<List<int>>
                {
                    new()
                    {
                        -2, 0, 2
                    }
                }
            },
        };

    #endregion

    #region + MaxAreaTests

    [Theory]
    [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new int[] { 1, 1 }, 1)]
    [InlineData(new int[] { 2, 3, 4, 5, 18, 17, 6 }, 17)]
    [InlineData(new int[] { 1, 1000, 1000, 6, 2, 5, 4, 8, 3, 7 }, 1000)]
    public void MaxAreaTests(int[] height, int expected)
    {
        var result = _sut.MaxArea(height);
        Assert.Equal(expected, result);
    }

    #endregion
}