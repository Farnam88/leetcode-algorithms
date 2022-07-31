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
        HashSet<char> window = new HashSet<char>();
        int left = 0, result = 0;
        for (int right = 0; right < s.Length; right++)
        {
            while (window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }

            window.Add(s[right]);
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
    public int CharacterReplacement(string s, int k)
    {
        int left = 0, result = 0;
        var mapping = new Dictionary<char, int>();
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

    #region + CheckInclusion

    /// <summary>
    /// https://leetcode.com/problems/permutation-in-string/submissions/
    /// 567. Permutation in String
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
        char[] strChar = new char[26];
        int left = 0, right = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            strChar[s1[i] - 'a']++;
        }

        var s1Str = new string(strChar);
        while (right < s2.Length)
        {
            strChar = new char[26];
            while (right < s1.Length + left && right < s2.Length)
            {
                strChar[s2[right] - 'a']++;
                right++;
            }

            var currentStr = new string(strChar);
            if (s1Str == currentStr)
                return true;
            left++;
            right = left;
        }

        return false;
    }

    /// <summary>
    /// https://leetcode.com/problems/permutation-in-string/submissions/
    /// 567. Permutation in String
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public bool CheckInclusion2(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
        char[] s1Chars = new char[26], s2Chars = new char[26];
        int matches = 0, left = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            s1Chars[s1[i] - 'a']++;
            s2Chars[s2[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
            matches += s1Chars[i] == s2Chars[i] ? 1 : 0;
        for (int right = s1.Length; right < s2.Length; right++)
        {
            if (matches == 26)
                return true;
            int index = s2[right] - 'a';
            s2Chars[index]++;

            if (s1Chars[index] == s2Chars[index])
                matches++;
            else if (s1Chars[index] + 1 == s2Chars[index])
                matches--;

            index = s2[left] - 'a';
            s2Chars[index]--;
            if (s1Chars[index] == s2Chars[index])
                matches++;
            else if (s1Chars[index] - 1 == s2Chars[index])
                matches--;
            left++;
        }

        return matches == 26;
    }

    #endregion
}