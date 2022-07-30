namespace Algorithm.Laboratory.SlidingWindow;

public class MediumSlidingWindow
{
    #region + LengthOfLongestSubstring

    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// 3. Longest Substring Without Repeating Characters
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1)
            return s.Length;
        HashSet<char> set = new HashSet<char>();
        int left = 0, result = 0;
        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left++;
            }

            set.Add(s[right]);
            result = Math.Max(result, (right - left + 1));
        }

        return result;
    }

    #endregion

    #region + CharacterReplacement

    /// <summary>
    /// https://leetcode.com/problems/longest-repeating-character-replacement/
    /// 424. Longest Repeating Character Replacement
    /// </summary>
    /// <param name="s">
    /// <code>1 &lt;= s.length &lt;= 105</code>
    /// </param>
    /// <param name="k">
    /// <code>0 &lt;= k &lt;= s.length</code>
    /// </param>
    /// <returns></returns>
    public int CharacterReplacement2(string s, int k)
    {
        int left = 0, result = 0, counter = 0;
        for (int right = 0; right < s.Length; right++)
        {
            var leftVal = s[left];
            var rightVal = s[right];
            if (leftVal == rightVal || (leftVal != rightVal && counter < k))
            {
                result = Math.Max(result, (right - left + 1));
                if (leftVal != rightVal)
                    counter++;
            }
            else
            {
                counter = 0;
                left++;
                right = left - 1;
            }
        }

        return result;
    }

    public int CharacterReplacement(string s, int k)
    {
        var mapping = new Dictionary<char, int>();
        int left = 0, result = 0;

        for (int right = 0; right < s.Length; right++)
        {
            mapping.TryAdd(s[right], 0);
            mapping[s[right]]++;
            while ((right - left + 1) - mapping.Values.Max() > k)
            {
                mapping.TryAdd(s[left], 0);
                mapping[s[left]]--;
                left++;
            }

            result = Math.Max(result, (right - left + 1));
        }

        return result;
    }

    #endregion
}