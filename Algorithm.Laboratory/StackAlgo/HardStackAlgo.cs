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
        int maxArea = 0;
        for (int currentIndex = 0; currentIndex < heights.Length; currentIndex++)
        {
            var indexPointer = currentIndex;
            while (stack.Count > 0 && heights[currentIndex] < stack.Peek().Height )
            {
                var previousRect = stack.Pop();
                maxArea = Math.Max(maxArea, (currentIndex - previousRect.Index) * previousRect.Height);
                indexPointer = previousRect.Index;
            }

            stack.Push((indexPointer, heights[currentIndex]));
        }

        while (stack.Count > 0)
        {
            var rectangle = stack.Pop();
            maxArea = Math.Max(maxArea, (heights.Length - rectangle.Index) * rectangle.Height);
        }

        return maxArea;
    }

    #endregion
}