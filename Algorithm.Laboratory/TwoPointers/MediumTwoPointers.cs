namespace Algorithm.Laboratory.TwoPointers;

public class MediumTwoPointers
{
    #region + TwoSum

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
}