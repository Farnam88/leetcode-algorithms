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
}