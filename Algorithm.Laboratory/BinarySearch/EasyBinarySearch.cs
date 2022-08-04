namespace Algorithm.Laboratory.BinarySearch;

public class EasyBinarySearch
{
    /// <summary>
    /// 704. Binary Search
    /// https://leetcode.com/problems/binary-search/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search(int[] nums, int target)
    {
        int right = nums.Length - 1, left = 0;
        while (left <= right)
        {
            var mid = (right + left) / 2;
            if (target > nums[mid])
                left = mid + 1;
            if (target < nums[mid])
                right = mid - 1;
            if (target == nums[mid])
                return mid;
        }

        return -1;
    }
}