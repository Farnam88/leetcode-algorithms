namespace Algorithm.Laboratory.TwoPointers;

public class HardTwoPointers
{
    #region + Trap

    /// <summary>
    /// 42. Trapping Rain Water
    /// https://leetcode.com/problems/trapping-rain-water/
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int Trap(int[] height)
    {
        if (height.Length <= 1)
            return 0;
        int result = 0, left = 0, right = height.Length - 1, maxLeft = height[left], maxRight = height[right];

        while (left < right)
        {
            if (maxLeft <= maxRight)
            {
                left++;
                maxLeft = Math.Max(maxLeft, height[left]);
                result += maxLeft - height[left];
            }
            else
            {
                right--;
                maxRight = Math.Max(maxRight, height[right]);
                result += maxRight - height[right];
            }
        }

        return result;
    }

    #endregion
}