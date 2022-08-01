﻿using System.Text;

namespace Algorithm.Laboratory.SlidingWindow;

public class HardSlidingWindow
{
    #region + MinWindow

    /// <summary>
    /// https://leetcode.com/problems/minimum-window-substring/
    /// 76. Minimum Window Substring
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public string MinWindow(string s, string t)
    {
        if (t == "" || t == s)
            return t;
        if (t.Length > s.Length)
            return "";
        var mapping = new Dictionary<char, int>();
        var window = new Dictionary<char, int>();
        for (int i = 0; i < t.Length; i++)
        {
            mapping.TryAdd(t[i], 0);
            mapping[t[i]]++;
        }

        int left = 0, length = int.MaxValue, have = 0, need = mapping.Count;
        (int left, int right) range = (0, 0);
        for (int right = 0; right < s.Length; right++)
        {
            var current = s[right];
            window.TryAdd(current, 0);
            window[current]++;
            if (mapping.ContainsKey(current) && window[current] == mapping[current])
                have++;
            while (have == need)
            {
                if ((right - left + 1) < length)
                {
                    length = right - left + 1;
                    range.left = left;
                    range.right = right + 1;
                }

                var currentLeft = s[left];
                window[currentLeft]--;
                if (mapping.ContainsKey(currentLeft) && mapping[currentLeft] > window[currentLeft])
                    have--;
                left++;
            }
        }

        return length != int.MaxValue ? s[range.left..range.right] : "";
    }

    #endregion

    #region + MaxSlidingWindow

    /// <summary>
    /// Monotonically Decreasing Queue
    /// https://leetcode.com/problems/sliding-window-maximum/
    /// 239. Sliding Window Maximum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        LinkedList<int> queue = new LinkedList<int>();
        List<int> result = new List<int>();
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            while (queue.Count > 0 && nums[queue.Last.Value] < nums[right])
                queue.RemoveLast();

            queue.AddLast(right);

            if (left > queue.First.Value)
                queue.RemoveFirst();
            if (right + 1 >= k)
            {
                result.Add(nums[queue.First.Value]);
                left++;
            }
        }

        return result.ToArray();
    }

    #endregion
}