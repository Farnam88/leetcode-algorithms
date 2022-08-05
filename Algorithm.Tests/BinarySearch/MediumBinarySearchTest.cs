namespace Algorithm.Tests.BinarySearch;

public class MediumBinarySearchTest
{
    private readonly MediumBinarySearch _sut;

    public MediumBinarySearchTest()
    {
        _sut = new MediumBinarySearch();
    }


    #region + SearchMatrixTest

    [Theory]
    [MemberData(nameof(SearchMatrixData))]
    public void SearchMatrix(int[][] matrix, int target, bool expected)
    {
        var result = _sut.SearchMatrix(matrix, target);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> SearchMatrixData =>
        new List<object[]>
        {
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3 },
                },
                2,
                false
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1 },
                },
                1,
                true
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 6 }
                },
                3,
                true
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 1, 3, 5, 7 },
                    new int[] { 10, 11, 16, 20 },
                    new int[] { 23, 30, 34, 60 }
                },
                13,
                false
            }
        };

    #endregion

    #region + MinEatingSpeedTest

    [Theory]
    [InlineData(new int[] { 3, 6, 7, 11 }, 8, 4)]
    [InlineData(new int[] { 30, 11, 23, 4, 20 }, 5, 30)]
    [InlineData(new int[] { 30, 11, 23, 4, 20 }, 6, 23)]
    public void MinEatingSpeedTest(int[] piles, int h, int expected)
    {
        var result = _sut.MinEatingSpeed(piles, h);

        Assert.Equal(expected, result);
    }

    #endregion
}