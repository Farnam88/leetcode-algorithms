namespace Algorithm.Laboratory.BinarySearch;

/// <summary>
/// 981. Time Based Key-Value Store
/// https://leetcode.com/problems/time-based-key-value-store/
/// </summary>
public class TimeMap
{
    private readonly Dictionary<string, IList<(string Val, int Time)>> _dictionary;

    public TimeMap()
    {
        _dictionary = new();
    }

    public void Set(string key, string value, int timestamp)
    {
        _dictionary.TryAdd(key, new List<(string val, int time)>());
        _dictionary[key].Add((value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        var result = string.Empty;

        if (!_dictionary.ContainsKey(key))
            return result;

        var values = _dictionary[key];
        int left = 0, right = values.Count - 1;

        while (left <= right)
        {
            int mid = (right + left) / 2;
            var midValue = values[mid];
            if (midValue.Time <= timestamp)
            {
                result = midValue.Val;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}