using System.Text;

namespace Algorithm.Laboratory.TwoPointers;

public class EasyTwoPointers
{
    #region + IsPalindrome

    /// <summary>
    /// 125. Valid Palindrome
    /// https://leetcode.com/problems/valid-palindrome/
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (right > left)
        {
            while (right > left && !char.IsLetterOrDigit(s[left]))
                left++;
            while (right > left && !char.IsLetterOrDigit(s[right]))
                right--;
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;
            left++;
            right--;
        }

        return true;
    }

    #endregion
}