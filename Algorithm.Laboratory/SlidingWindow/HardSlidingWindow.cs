using System.Text;

namespace Algorithm.Laboratory.SlidingWindow;

public class HardSlidingWindow
{
    #region + MinWindow

    /// <summary>
    /// https://leetcode.com/problems/minimum-window-substring/
    /// 76. Minimum Window Substring
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public string MinWindow(string s, string t)
    {
        if (t == "")
            return "";
        var countT = new Dictionary<char, int>();
        var window = new Dictionary<char, int>();
        for (int i = 0; i < t.Length; i++)
        {
            countT.TryAdd(t[i], 0);
            countT[t[i]]++;
        }

        int left = 0, have = 0, need = countT.Count;
        int[] result = new int[2];
        int lenght = int.MaxValue;
        for (int right = 0; right < s.Length; right++)
        {
            char current = s[right];
            window.TryAdd(current, 0);
            window[current]++;
            if (countT.ContainsKey(current) && window[current] == countT[current])
                have++;
            while (have == need)
            {
                if ((right - left + 1) < lenght)
                {
                    result[0] = left;
                    result[1] = right;
                    lenght = right - left + 1;
                }

                char currentLeft = s[left];

                window[currentLeft]--;
                if (countT.ContainsKey(s[left]) && window[currentLeft] < countT[currentLeft])
                    have--;
                left++;
            }
        }

        int l = result[0];
        int r = result[1] + 1;
        return lenght != int.MaxValue ? s[l..r] : "";
    }

    #endregion
}