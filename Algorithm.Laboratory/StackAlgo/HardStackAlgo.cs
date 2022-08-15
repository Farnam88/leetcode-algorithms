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
        
        Stack<(int Index, int Height)> stack = new();
        int maxArea = -1;

        for (int right = 0; right < heights.Length; right++)
        {
            int startIndex = right;
            
            while (stack.Count > 0 && stack.Peek().Height > heights[right])
            {
                var prevRec = stack.Pop();
                maxArea = Math.Max(maxArea, (right - prevRec.Index) * prevRec.Height);
                startIndex = prevRec.Index;
            }

            stack.Push((startIndex, heights[right]));
        }

        while (stack.Count > 0)
        {
            var rect = stack.Pop();
            maxArea = Math.Max(maxArea, (heights.Length - rect.Index) * rect.Height);
        }

        return maxArea;
    }

    #endregion
}