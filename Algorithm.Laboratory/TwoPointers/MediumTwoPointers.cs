namespace Algorithm.Laboratory.TwoPointers;

public class MediumTwoPointers
{
    #region + TwoSum

    /// <summary>
    /// 167. Two Sum II - Input Array Is Sorted
    /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        int left = 0, right = numbers.Length - 1;
        while (right > left)
        {
            var currentSum = numbers[left] + numbers[right];
            if (currentSum > target)
                right--;
            if (currentSum < target)
                left++;
            if (currentSum == target)
            {
                result[0] = left + 1;
                result[1] = right + 1;
                break;
            }
        }

        return result;
    }

    #endregion

    #region + ThreeSum

    /// <summary>
    /// 15. 3Sum
    /// https://leetcode.com/problems/3sum/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>List of list of int</returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();

        Array.Sort(nums);

        for (int current = 0; current < nums.Length; current++)
        {
            var beginValue = nums[current];
            if (current > 0 && beginValue == nums[current - 1])
                continue;
            int left = current + 1, right = nums.Length - 1;
            while (right > left)
            {
                var sum = beginValue + nums[left] + nums[right];
                if (sum > 0)
                    right--;
                if (sum < 0)
                    left++;
                if (sum == 0)
                {
                    result.Add(new List<int>() {beginValue, nums[left], nums[right]});
                    left++;
                    while (right > left && nums[left] == nums[left - 1])
                        left++;
                }
            }
        }


        return result;
    }

    #endregion

    #region + MaxArea

    /// <summary>
    /// 11. Container With Most Water
    /// https://leetcode.com/problems/container-with-most-water/
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