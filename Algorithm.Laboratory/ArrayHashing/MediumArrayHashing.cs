using System.Text;

namespace Algorithm.Laboratory.ArrayHashing;

public class MediumArrayHashing
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> mapping = new Dictionary<string, List<string>>();

        for (int j = 0; j < strs.Length; j++)
        {
            var keyChar = new char[26];

            for (int i = 0; i < strs[j].Length; i++)
            {
                keyChar[strs[j][i] - 'a']++;
            }

            string key = new string(keyChar);
            mapping.TryAdd(key, new List<string>());
            mapping[key].Add(strs[j]);
        }

        return new List<IList<string>>(mapping.Values);
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        int[] result = new int[k];
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        List<int>[] bucket = new List<int>[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            mapping.TryAdd(nums[i], 0);
            mapping[nums[i]]++;
        }

        foreach (var item in mapping)
        {
            var index = item.Value;
            int value = item.Key;
            if (bucket[index] is null)
                bucket[index] = new List<int>();
            bucket[index].Add(value);
        }

        var arrIndex = 0;
        for (int i = bucket.Length - 1; i >= 0 && arrIndex < k; i--)
        {
            if (bucket[i] is not null)
                for (int j = 0; j < bucket[i].Count && arrIndex < k; j++)
                {
                    result[arrIndex] = bucket[i][j];
                    arrIndex++;
                }
        }

        return result;
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int inputLenght = nums.Length;
        int[] result = new int[inputLenght];
        Array.Fill(result, 1);
        int pre = 1;
        int post = 1;
        for (int i = 0; i < inputLenght; i++)
        {
            result[i] *= pre;
            pre *= nums[i];
            int reverseIndex = (inputLenght - 1) - i;
            result[reverseIndex] *= post;
            post *= nums[reverseIndex];
        }

        return result;
    }

    public bool IsValidSudoku(char[][] board)
    {
        var col = new Dictionary<int, HashSet<char>>(9);
        var row = new Dictionary<int, HashSet<char>>(9);
        var square = new Dictionary<int, HashSet<char>>(9);
        for (int i = 0; i < 9; i++)
        {
            row.TryAdd(i, new HashSet<char>());
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] == '.')
                    continue;
                col.TryAdd(j, new HashSet<char>());
                int squarekey = (i / 3) * 3 + (j / 3);
                square.TryAdd(squarekey, new HashSet<char>());

                if (row[i].Contains(board[i][j]) ||
                    col[j].Contains(board[i][j]) ||
                    square[squarekey].Contains(board[i][j]))
                    return false;
                row[i].Add(board[i][j]);
                col[j].Add(board[i][j]);
                square[squarekey].Add(board[i][j]);
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
        var set = new HashSet<int>(nums);
        int result = 0;
        foreach (var item in set)
        {
            if (set.Contains(item - 1))
                continue;
            int j = 1;
            while (set.Contains(item + j))
            {
                j++;
            }
            result = j > result ? j : result;
        }

        return result;
    }
}