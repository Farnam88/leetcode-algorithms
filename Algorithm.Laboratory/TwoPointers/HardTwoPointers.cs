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
        int result = 0, left = 0, right = height.Length - 1;
        int leftMax = height[left], rightMax = height[right];
        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                result += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                result += rightMax - height[right];
            }
        }

        return result;
    }

    #endregion
}