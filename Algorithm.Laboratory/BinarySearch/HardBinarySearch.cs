namespace Algorithm.Laboratory.BinarySearch;

public class HardBinarySearch
{
    /// <summary>
    /// 4. Median of Two Sorted Arrays
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] shortArr = nums1.Length < nums2.Length ? nums1 : nums2;
        int[] longArr = nums1.Length < nums2.Length ? nums2 : nums1;

        int total = shortArr.Length + longArr.Length;
        int half = total / 2;
        int left = 0, right = shortArr.Length - 1;
        
        while (true)
        {
            int sMid = (int)Math.Floor((left + right) / (decimal)2);
            int lMid = half - sMid - 2;

            int shortMid = sMid >= 0 ? shortArr[sMid] : int.MinValue;
            int shortRight = sMid + 1 < shortArr.Length ? shortArr[sMid + 1] : int.MaxValue;

            int longMid = lMid >= 0 ? longArr[lMid] : int.MinValue;
            int longRight = lMid + 1 < longArr.Length ? longArr[lMid + 1] : int.MaxValue;

            if (shortMid <= longRight && longMid <= shortRight)
            {
                if (total % 2 != 0)
                {
                    return Math.Min(shortRight, longRight);
                }

                return (Math.Max(shortMid, longMid) + Math.Min(shortRight, longRight)) / (double)2;
            }
            else if (shortMid > longRight)
                right = sMid - 1;
            else
                left = sMid + 1;
        }
    }
}