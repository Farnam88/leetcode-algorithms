namespace Algorithm.Laboratory.StackAlgo;

public class EasyStackAlgo
{
    #region + IsValid

    /// <summary>
    /// https://leetcode.com/problems/valid-parentheses/
    /// 20. Valid Parentheses
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0)
            return false;
        Stack<char> stack = new Stack<char>();
        var closeOpen = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        for (int i = 0; i < s.Length; i++)
        {
            if (!closeOpen.ContainsKey(s[i]))
                stack.Push(s[i]);
            else if (stack.Count > 0 && stack.Peek() == closeOpen[s[i]])
                stack.Pop();
            else
                return false;
        }

        return stack.Count == 0;
    }

    #endregion
}