using System.Text;

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
        if (t.Length > s.Length)
            return string.Empty;

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
            var currentChar = s[right];
            window.TryAdd(currentChar, 0);
            window[currentChar]++;

            if (mapping.ContainsKey(currentChar) && mapping[currentChar] == window[currentChar])
                have++;

            while (have == need)
            {
                var windowLength = right - left + 1;
                if (windowLength < length)
                {
                    length = windowLength;
                    range.left = left;
                    range.right = right + 1;
                }

                currentChar = s[left];
                window[currentChar]--;
                if (mapping.ContainsKey(currentChar) && mapping[currentChar] > window[currentChar])
                    have--;
                left++;
            }
        }

        return length != int.MaxValue ? s[range.left..range.right] : string.Empty;
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