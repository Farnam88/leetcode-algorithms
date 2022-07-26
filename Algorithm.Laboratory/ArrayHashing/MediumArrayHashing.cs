﻿using System.Text;

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
            char[] chars = new char[26];
            for (int j = 0; j < strs[i].Length; j++)
            {
                chars[strs[i][j] - 'a']++;
            }

            var key = new string(chars);
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
        Dictionary<int, int> mapping = new();
        var result = new int[k];
        for (int i = 0; i < nums.Length; i++)
        {
            mapping.TryAdd(nums[i], 0);
            mapping[nums[i]]++;
        }

        var bucket = new List<int>[nums.Length + 1];
        foreach (var item in mapping)
        {
            var key = item.Value;
            var value = item.Key;
            bucket[key] ??= new List<int>();
            bucket[key].Add(value);
        }

        int indexArr = 0;
        for (int i = bucket.Length - 1; i >= 0 && indexArr < k; i--)
        {
            if (bucket[i] is not null)
            {
                for (int j = 0; j < bucket[i].Count && indexArr < k; j++)
                {
                    result[indexArr] = bucket[i][j];
                    indexArr++;
                }
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
        int[] result = new int[nums.Length];
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
        Dictionary<int, HashSet<char>> cols = new(), rows = new(), qubes = new();
        for (int row = 0; row < 9; row++)
        {
            rows.TryAdd(row, new HashSet<char>());
            for (int col = 0; col < 9; col++)
            {
                var currentPoint = board[row][col];
                if (currentPoint == '.')
                    continue;

                int qube = (row / 3) * 3 + (col / 3);

                cols.TryAdd(col, new HashSet<char>());
                qubes.TryAdd(qube, new HashSet<char>());

                if (cols[col].Contains(currentPoint) ||
                    rows[row].Contains(currentPoint) ||
                    qubes[qube].Contains(currentPoint))
                    return false;

                cols[col].Add(currentPoint);
                rows[row].Add(currentPoint);
                qubes[qube].Add(currentPoint);
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