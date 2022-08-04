using System.Text;

namespace Algorithm.Laboratory.SlidingWindow;

public class HardSlidingWindow
{
    #region + MinWindow

    /// <summary>
    /// 76. Minimum Window Substring
    /// https://leetcode.com/problems/minimum-window-substring/
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public string MinWindow(string s, string t)
    {
        if (t.Length > s.Length)
            return string.Empty;
        var mapping = new Dictionary<char, int>();
        var window = new Dictionary<char, int>();
        var a = new Stack<char>();
        var b = a.Count(c => c == 'a');
        for (int i = 0; i < t.Length; i++)
        {
            mapping.TryAdd(t[i], 0);
            mapping[t[i]]++;
        }

        int left = 0, length = int.MaxValue, have = 0, need = mapping.Count;
        (int Left, int Right) range = new();

        for (int right = 0; right < s.Length; right++)
        {
            var current = s[right];
            window.TryAdd(current, 0);
            window[current]++;

            if (mapping.ContainsKey(current) && window[current] == mapping[current])
                have++;
            while (have == need)
            {
                var windowCurrentLength = right - left + 1;
                if (windowCurrentLength < length)
                {
                    length = windowCurrentLength;
                    range.Left = left;
                    range.Right = right + 1;
                }

                current = s[left];
                window[current]--;
                if (mapping.ContainsKey(current) && mapping[current] > window[current])
                    have--;
                left++;
            }
        }

        return length != int.MaxValue ? s[range.Left..range.Right] : string.Empty;
    }

    #endregion

    #region + MaxSlidingWindow

    /// <summary>
    /// 239. Sliding Window Maximum
    /// Monotonically Decreasing Queue
    /// https://leetcode.com/problems/sliding-window-maximum/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == k)
            return new[] { nums.Max() };
        List<int> result = new();
        LinkedList<int> window = new();
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            while (window.Count > 0 && nums[window.Last.Value] < nums[right])
            {
                window.RemoveLast();
            }

            window.AddLast(right);

            if (left > window.First.Value)
                window.RemoveFirst();
            if (right + 1 >= k)
            {
                result.Add(nums[window.First.Value]);
                left++;
            }
        }

        return result.ToArray();
    }

    #endregion
}