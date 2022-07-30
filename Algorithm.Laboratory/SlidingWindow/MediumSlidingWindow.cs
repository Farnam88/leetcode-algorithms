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
        char[] charBytes = new char[26];
        for (int i = 0; i < s1.Length; i++)
        {
            charBytes[s1[i] - 'a']++;
        }

        var s1Str = new string(charBytes);
        int left = 0, right = 0;
        while (right < s2.Length)
        {
            charBytes = new char[26];
            while (right < s1.Length + left && right < s2.Length)
            {
                charBytes[s2[right] - 'a']++;
                right++;
            }

            var subString = new string(charBytes);
            if (subString == s1Str)
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
        char[] S1Count = new char[26], s2Count = new char[26];
        int matches = 0, left = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            S1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
            matches += S1Count[i] == s2Count[i] ? 1 : 0;

        for (int right = s1.Length; right < s2.Length; right++)
        {
            if (matches == 26)
                return true;

            var index = s2[right] - 'a';
            s2Count[index]++;
            if (S1Count[index] == s2Count[index])
                matches++;
            else if (S1Count[index] + 1 == s2Count[index])
                matches--;

            index = s2[left] - 'a';
            s2Count[index]--;
            if (S1Count[index] == s2Count[index])
                matches++;
            else if (S1Count[index] - 1 == s2Count[index])
                matches--;
            left++;
        }

        return matches == 26;
    }

    #endregion
}