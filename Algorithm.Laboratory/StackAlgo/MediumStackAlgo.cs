namespace Algorithm.Laboratory.StackAlgo;

public class MediumStackAlgo
{
    #region + MinStackOperation

    /// <summary>
    /// https://leetcode.com/problems/min-stack/
    /// 155. Min Stack
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public int[] MinStackOperation(int[] input)
    {
        MinStack minStack = new MinStack();
        for (int i = 0; i < input.Length; i++)
        {
            minStack.Push(input[i]);
        }

        var firstMin = minStack.GetMin();
        minStack.Pop();
        minStack.Top();
        var secondMin = minStack.GetMin();

        return new int[] { firstMin, secondMin };
    }

    #endregion

    #region + EvalRPN

    /// <summary>
    /// https://leetcode.com/problems/evaluate-reverse-polish-notation/
    /// 150. Evaluate Reverse Polish Notation
    /// </summary>
    /// <param name="tokens"></param>
    /// <returns></returns>
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++)
        {
            var currentStr = tokens[i];
            if (int.TryParse(currentStr, out int current))
            {
                stack.Push(current);
            }
            else
            {
                if (currentStr == "+")
                    stack.Push(stack.Pop() + stack.Pop());
                if (currentStr == "-")
                {
                    (int, int) items = (stack.Pop(), stack.Pop());
                    stack.Push(items.Item2 - items.Item1);
                }

                if (currentStr == "/")
                {
                    (int, int) items = (stack.Pop(), stack.Pop());
                    stack.Push(items.Item2 / items.Item1);
                }

                if (currentStr == "*")
                    stack.Push(stack.Pop() * stack.Pop());
            }
        }
        return stack.First();
    }

    #endregion
}