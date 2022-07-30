using System.Text;

namespace Algorithm.Laboratory.TwoPointers;

public class EasyTwoPointers
{
    #region + IsPalindrome

    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome/
    /// 125. Valid Palindrome
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsPalindrome(string s)
    {
        int rInd = s.Length - 1;
        int ind = 0;
        while (ind < rInd)
        {
            while (ind < rInd && !char.IsLetterOrDigit(s[ind]))
                ind++;
            while (ind < rInd && !char.IsLetterOrDigit(s[rInd]))
                rInd--;
            if (char.ToLower(s[ind]) != char.ToLower(s[rInd]))
                return false;
            ind++;
            rInd--;
        }

        return true;
    }

    #endregion

}