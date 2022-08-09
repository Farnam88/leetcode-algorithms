namespace Algorithm.Tests.BinarySearch;

public class HardBinarySearchTests
{
    private readonly HardBinarySearch _sut;

    public HardBinarySearchTests()
    {
        _sut = new HardBinarySearch();
    }

    #region MyRegion

    [Theory]
    [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2.00000)]
    [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.50000)]
    [InlineData(new int[] { 4, 5, 6, 7, 8 }, new int[] { 0, 1, 3, 5 }, 5)]
    public void FindMedianSortedArrays(int[] nums1, int[] nums2, double expected)
    {
        var result = _sut.FindMedianSortedArrays(nums1, nums2);

        Assert.Equal(expected, result);
    }

    #endregion
}