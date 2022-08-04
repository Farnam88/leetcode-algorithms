namespace Algorithm.Laboratory.StackAlgo;

public class HardStackAlgo
{
    #region + LargestRectangleArea

    /// <summary>
    /// 84. Largest Rectangle in Histogram
    /// https://leetcode.com/problems/largest-rectangle-in-histogram/
    /// </summary>
    /// <param name="heights"></param>
    /// <returns></returns>
    public int LargestRectangleArea(int[] heights)
    {
        if (heights.Length < 2)
            return heights[0];
        int maxArea = -1;

        Stack<(int Index, int Height)> stack = new();
        for (int right = 0; right < heights.Length; right++)
        {
            int start = right;
            while (stack.Count > 0 && stack.Peek().Height > heights[right])
            {
                var prevRect = stack.Pop();
                maxArea = Math.Max(maxArea, (right - prevRect.Index) * prevRect.Height);
                start = prevRect.Index;
            }

            stack.Push((start, heights[right]));
        }

        while (stack.Count > 0)
        {
            var rect = stack.Pop();
            maxArea = Math.Max(maxArea, rect.Height * (heights.Length - rect.Index));
        }

        return maxArea;
    }

    #endregion
}