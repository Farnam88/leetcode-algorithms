using System.Text;

namespace Algorithm.Laboratory.TwoPointers;

public class EasyTwoPointers
{
    public bool IsPalindrome(string s)
    {
        int r = s.Length - 1;
        int l = 0;
        while (l < r)
        {
            while (l < r && !char.IsLetterOrDigit(s[l]))
                l++;

            while (r > l && !char.IsLetterOrDigit(s[r]))
                r--;

            if (char.ToLower(s[l]) != char.ToLower(s[r]))
                return false;
            l++;
            r--;
        }

        return true;
    }
}