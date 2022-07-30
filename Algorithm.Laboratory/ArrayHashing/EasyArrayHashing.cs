namespace Algorithm.Laboratory.ArrayHashing;

public class EasyArrayHashing
{
    #region + ContainsDuplicate

    /// <summary>
    /// https://leetcode.com/problems/contains-duplicate/
    /// 217. Contains Duplicate
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool ContainsDuplicate(int[] nums)
    {
        var hahSet = new HashSet<int>(nums);
        return nums.Length != hahSet.Count;
    }

    #endregion

    #region + IsAnagram

    /// <summary>
    /// https://leetcode.com/problems/valid-anagram/
    /// 242. Valid Anagram
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        var countA = new Dictionary<char, int>();
        var countT = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (countA.TryGetValue(s[i], out int valS))
                countA[s[i]] = 1 + valS;
            else
            {
                countA[s[i]] = 1;
            }

            if (countT.TryGetValue(t[i], out int valT))
                countT[t[i]] = 1 + valT;
            else
            {
                countT[t[i]] = 1;
            }
        }

        foreach (var i in countA)
        {
            if (countT.TryGetValue(i.Key, out int valT))
            {
                if (i.Value == valT)
                    continue;
                return false;
            }

            return false;
        }

        return true;
    }

    #endregion

    #region + TwoSum

    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// 1. Two Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        return new int[] { };
    }

    #endregion
}