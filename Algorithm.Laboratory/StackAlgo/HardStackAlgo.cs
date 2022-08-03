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

        int manxArea = -1;
        Stack<(int Index, int Height)> stack = new();

        for (int right = 0; right < heights.Length; right++)
        {
            int start = right;
            while (stack.Count > 0 && stack.Peek().Height > heights[right])
            {
                var pair = stack.Pop();
                manxArea = Math.Max(manxArea, pair.Height * (right - pair.Index));
                start = pair.Index;
            }

            stack.Push((start, heights[right]));
        }

        var stackLength = stack.Count;
        for (int i = 0; i < stackLength; i++)
        {
            var pair = stack.Pop();
            manxArea = Math.Max(manxArea, pair.Height * (heights.Length - pair.Index));
        }

        return manxArea;
    }

    #endregion
}