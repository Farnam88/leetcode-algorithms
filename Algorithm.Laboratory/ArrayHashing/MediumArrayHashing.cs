using System.Linq.Expressions;
using System.Text;

namespace Algorithm.Laboratory.ArrayHashing;

public class MediumArrayHashing
{
    #region + GroupAnagrams

    /// <summary>
    /// 49. Group Anagrams
    /// https://leetcode.com/problems/group-anagrams/
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> mapping = new();
        for (int i = 0; i < strs.Length; i++)
        {
            char[] charArr = new char[26];
            for (int j = 0; j < strs[i].Length; j++)
            {
                charArr[strs[i][j] - 'a']++;
            }

            var key = new string(charArr);
            mapping.TryAdd(key, new List<string>());
            mapping[key].Add(strs[i]);
        }

        return mapping.Values.ToList();
    }

    #endregion

    #region + TopKFrequent

    /// <summary>
    /// 347. Top K Frequent Elements
    /// https://leetcode.com/problems/top-k-frequent-elements/
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> countMap = new();
        for (int i = 0; i < nums.Length; i++)
        {
            countMap.TryAdd(nums[i], 0);
            countMap[nums[i]]++;
        }

        var bucket = new List<int>[nums.Length + 1];
        foreach (var item in countMap)
        {
            var key = item.Value;
            var value = item.Key;
            bucket[key] ??= new List<int>();
            bucket[key].Add(value);
        }

        var result = new int[k];
        var qt = 0;
        for (int i = bucket.Length - 1; i >= 0 && qt < k; i--)
        {
            if (bucket[i] is null)
                continue;
            for (int j = 0; j < bucket[i].Count && qt < k; j++)
            {
                result[qt] = bucket[i][j];
                qt++;
            }
        }

        return result;
    }

    #endregion

    #region + ProductExceptSelf

    /// <summary>
    /// 238. Product of Array Except Self
    /// https://leetcode.com/problems/product-of-array-except-self/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ProductExceptSelf(int[] nums)
    {
        int left = 1, right = 1, revIndex = nums.Length - 1;
        var result = new int[nums.Length];
        Array.Fill(result, 1);
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] *= left;
            left *= nums[i];
            result[revIndex - i] *= right;
            right *= nums[revIndex - i];
        }

        return result;
    }

    #endregion

    #region + IsValidSudoku

    /// <summary>
    /// 36. Valid Sudoku
    /// https://leetcode.com/problems/valid-sudoku/
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudoku(char[][] board)
    {
        Dictionary<int, List<char>> rows = new(), cols = new();
        Dictionary<(int, int), List<char>> box = new();
        for (int r = 0; r < 9; r++)
        {
            rows.TryAdd(r, new List<char>());
            for (int c = 0; c < 9; c++)
            {
                var boxKey = (r / 3, c / 3);
                cols.TryAdd(c, new List<char>());
                box.TryAdd(boxKey, new List<char>());
                var currentChar = board[r][c];
                if (currentChar == '.')
                    continue;
                if (rows[r].Contains(currentChar) ||
                    cols[c].Contains(currentChar) ||
                    box[boxKey].Contains(currentChar))
                    return false;
                rows[r].Add(currentChar);
                cols[c].Add(currentChar);
                box[boxKey].Add(currentChar);
            }

        }
        return true;
    }

    #endregion

    #region + Encode and Decode

    /// <summary>
    /// 659 · Encode and Decode Strings
    /// https://www.lintcode.com/problem/659/
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public String encode(List<String> strs)
    {
        StringBuilder strb = new StringBuilder();
        foreach (var str in strs)
        {
            strb.Append($"{str.Length}#");
            strb.Append(str);
        }

        return strb.ToString();
    }

    /// <summary>
    /// https://www.lintcode.com/problem/659/
    /// 659 · Encode and Decode Strings
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public List<String> decode(String str)
    {
        int i = 0;
        var res = new List<string>();

        while (i < str.Length)
        {
            int j = i;
            while (str[j] != '#')
                j++;
            int lenght = int.Parse(str[i..j]);
            int endIndex = j + 1 + lenght;
            res.Add(str[(j + 1)..endIndex]);
            i = endIndex;
        }

        return res;
    }

    #endregion

    #region + LongestConsecutive

    /// <summary>
    /// 128. Longest Consecutive Sequence
    /// https://leetcode.com/problems/longest-consecutive-sequence/
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> input = new(nums);
        int result = 0;
        foreach (var item in input)
        {
            if (input.Contains(item - 1))
                continue;
            int j = 1;
            while (input.Contains(item + j))
                j++;
            result = result > j ? result : j;
        }

        return result;
    }

    #endregion
}