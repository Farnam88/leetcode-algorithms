using System.Text;

namespace Algorithm.Laboratory.TwoPointers;

public class EasyTwoPointers
{
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
}