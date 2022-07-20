namespace Algorithm.Laboratory.ArrayHashing;

public class EasyArrayHashing
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hahSet = new HashSet<int>(nums);
        return nums.Length != hahSet.Count;
    }

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
}