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
        if (t == "")
            return string.Empty;
        Dictionary<char, int> targetMapping = new(), currentWindow = new();
        foreach (var item in t)
        {
            targetMapping.TryAdd(item, 0);
            targetMapping[item]++;
        }

        int left = 0, minLength = int.MaxValue, have = 0, need = targetMapping.Count;
        (int Left, int Right) range = new();


        for (int right = 0; right < s.Length; right++)
        {
            var currentChar = s[right];
            currentWindow.TryAdd(currentChar, 0);
            currentWindow[currentChar]++;

            if (targetMapping.ContainsKey(currentChar) && targetMapping[currentChar] == currentWindow[currentChar])
                have++;
            while (have == need)
            {
                int currentLength = right - left + 1;
                if (currentLength < minLength)
                {
                    minLength = currentLength;
                    range.Left = left;
                    range.Right = right + 1;
                }

                currentChar = s[left];
                currentWindow[currentChar]--;
                if (targetMapping.ContainsKey(currentChar) && targetMapping[currentChar] > currentWindow[currentChar])
                    have--;
                left++;
            }
        }

        return minLength != int.MinValue ? s[range.Left..range.Right] : string.Empty;
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
        if (nums.Length < k)
            return new[] {nums.Max()};
        List<int> result = new();
        LinkedList<int> winOfIndices = new();
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            while (winOfIndices.Count > 0 && nums[winOfIndices.Last()] < nums[right])
                winOfIndices.RemoveLast();
            winOfIndices.AddLast(right);

            if (left > winOfIndices.First!.Value)
                winOfIndices.RemoveFirst();

            if (right + 1 >= k)
            {
                result.Add(nums[winOfIndices.First()]);
                left++;
            }
        }

        return result.ToArray();
    }

    #endregion
}