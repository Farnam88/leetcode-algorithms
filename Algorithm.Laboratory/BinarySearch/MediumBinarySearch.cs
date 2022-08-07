namespace Algorithm.Laboratory.BinarySearch;

public class MediumBinarySearch
{
    #region + SearchMatrix

    /// <summary>
    /// 74. Search a 2D Matrix
    /// https://leetcode.com/problems/search-a-2d-matrix/
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length - 1, col = matrix[0].Length - 1, top = 0, bot = rows;

        while (top <= bot)
        {
            int midRow = (top + bot) / 2;
            if (target > matrix[midRow][^1])
                top = midRow + 1;
            else if (target < matrix[midRow][0])
                bot = midRow - 1;
            else
                break;
        }

        if (!(top <= bot))
            return false;
        int right = col, left = 0;
        int row = (top + bot) / 2;
        while (left <= right)
        {
            var mid = (right + left) / 2;
            if (target > matrix[row][mid])
                left = mid + 1;
            else if (target < matrix[row][mid])
                right = mid - 1;
            else
                return true;
        }

        return false;
    }

    #endregion

    #region + MinEatingSpeed

    /// <summary>
    /// 875. Koko Eating Bananas
    /// https://leetcode.com/problems/koko-eating-bananas/
    /// </summary>
    /// <param name="piles"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1, right = piles.Max();
        decimal result = right;
        while (left <= right)
        {
            var mid = (right + left) / 2;
            decimal hours = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                hours += Math.Ceiling(piles[i] / (decimal)mid);
            }

            if (hours <= h)
            {
                result = Math.Min(result, mid);
                right = mid - 1;
            }
            else
                left = mid + 1;
        }

        return (int)result;
    }

    #endregion

    #region + Search

    /// <summary>
    /// 33. Search in Rotated Sorted Array
    /// https://leetcode.com/problems/search-in-rotated-sorted-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            var mid = (right + left) / 2;

            if (target == nums[mid])
                return mid;

            //Left Sorted Portion
            if (nums[mid] >= nums[left])
            {
                //Not fit in left portion
                if (target > nums[mid] || target < nums[left])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            //Right sorted Portion
            else
            {
                //Not fit in right portion
                if (target < nums[mid] || target > nums[right])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
        }

        return -1;
    }

    #endregion

    #region + FindMin

    /// <summary>
    /// 153. Find Minimum in Rotated Sorted Array
    /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1, result = nums[left];

        while (left <= right)
        {
            if (nums[left] < nums[right])
            {
                result = Math.Min(result, nums[left]);
                break;
            }

            int middle = (right + left) / 2;
            result = Math.Min(result, nums[middle]);
            
            if (nums[middle] >= nums[left])
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return result;
    }

    #endregion
}