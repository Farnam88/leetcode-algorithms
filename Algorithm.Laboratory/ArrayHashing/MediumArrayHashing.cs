using System.Text;

namespace Algorithm.Laboratory.ArrayHashing;

public class MediumArrayHashing
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var result = new Dictionary<string, IList<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var keyChar = new char[26];
            for (int j = 0; j < strs[i].Length; j++)
            {
                keyChar[strs[i][j] - 'a']++;
            }

            var key = new string(keyChar);
            result.TryAdd(key, new List<string>());
            result[key].Add(strs[i]);
        }

        return result.Values.ToList();
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        var grouping = new Dictionary<int, int>();
        var result = new int[k];
        foreach (var item in nums)
        {
            grouping.TryAdd(item, 0);
            grouping[item]++;
        }

        var bucket = new List<int>[nums.Length + 1];
        foreach (var item in grouping)
        {
            var key = item.Value;
            var value = item.Key;
            if (bucket[key] is null)
                bucket[key] = new List<int>();
            bucket[key].Add(value);
        }

        var arrIndex = 0;
        for (int i = bucket.Length - 1; i >= 0 && arrIndex < k; i--)
        {
            if (bucket[i] is not null)
            {
                for (int j = 0; j < bucket[i].Count && arrIndex < k; j++)
                {
                    result[arrIndex] = bucket[i][j];
                    arrIndex++;
                }
            }
        }

        return result;
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        var length = nums.Length;
        var result = new int[length];
        Array.Fill(result, 1);
        var pre = 1;
        var post = 1;
        var revIndex = length - 1;
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] *= pre;
            pre *= nums[i];
            result[revIndex - i] *= post;
            post *= nums[revIndex - i];
        }

        return result;
    }

    public bool IsValidSudoku(char[][] board)
    {
        var col = new Dictionary<int, HashSet<char>>(9);
        var row = new Dictionary<int, HashSet<char>>(9);
        var qube = new Dictionary<int, HashSet<char>>(9);

        for (int i = 0; i < 9; i++)
        {
            row.TryAdd(i, new HashSet<char>());

            for (int j = 0; j < 9; j++)
            {
                var value = board[i][j];
                if (value == '.')
                    continue;
                int qubeKey = (i / 3) * 3 + (j / 3);

                col.TryAdd(j, new HashSet<char>());

                qube.TryAdd(qubeKey, new HashSet<char>());

                if (col[j].Contains(value) ||
                    row[i].Contains(value) ||
                    qube[qubeKey].Contains(value))
                    return false;
                col[j].Add(value);
                row[i].Add(value);
                qube[qubeKey].Add(value);
            }
        }

        return true;
    }

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

    public int LongestConsecutive(int[] nums)
    {
        var input = new HashSet<int>(nums);
        int result = 0;
        foreach (var item in input)
        {
            if (nums.Contains(item - 1))
                continue;
            int j = 1;
            while (input.Contains(item + j))
                j++;
            result = j > result ? j : result;
        }

        return result;
    }
}