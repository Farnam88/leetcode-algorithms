namespace Algorithm.Tests.BinarySearch;

public class EasyBinarySearchTests
{
    private readonly EasyBinarySearch _sut;

    public EasyBinarySearchTests()
    {
        _sut = new EasyBinarySearch();
    }

    [Theory]
    [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4)]
    [InlineData(new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1)]
    public void Search(int[] nums, int target, int expected)
    {
        var result = _sut.Search(nums, target);

        Assert.Equal(expected, result);
    }
}