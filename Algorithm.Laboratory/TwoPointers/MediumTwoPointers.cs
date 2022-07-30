namespace Algorithm.Laboratory.TwoPointers;

public class MediumTwoPointers
{
    #region + TwoSum

    /// <summary>
    /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    /// 167. Two Sum II - Input Array Is Sorted
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] numbers, int target)
    {
        int[] result = new int[2];
        int left = 0;
        int right = numbers.Length - 1;
        while (left < right)
        {
            int currentSum = numbers[left] + numbers[right];
            if (currentSum > target)
                right--;
            if (currentSum < target)
                left++;
            if (currentSum == target)
            {
                result[0] = left + 1;
                result[1] = right + 1;
                return result;
            }
        }

        return result;
    }

    #endregion

    #region + ThreeSum

    /// <summary>
    /// https://leetcode.com/problems/3sum/
    /// 15. 3Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            var currentValue = nums[i];
            if (i > 0 && currentValue == nums[i - 1])
                continue;
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                var currentSum = currentValue + nums[left] + nums[right];
                if (currentSum > 0)
                    right--;
                if (currentSum < 0)
                    left++;
                if (currentSum == 0)
                {
                    result.Add(new List<int> { currentValue, nums[left], nums[right] });
                    left++;
                    while (left < right && nums[left] == nums[left - 1])
                        left++;
                }
            }
        }

        return result;
    }

    #endregion

    #region + MaxArea

    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/
    /// 11. Container With Most Water
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxVol = 0;
        while (left < right)
        {
            var vol = Math.Min(height[left], height[right]) * (right - left);
            maxVol = Math.Max(maxVol, vol);
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxVol;
    }

    #endregion
}