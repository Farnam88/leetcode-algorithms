namespace Algorithm.Laboratory.StackAlgo;

public class MediumStackAlgo
{
    #region + MinStackOperation

    /// <summary>
    /// 155. Min Stack
    /// https://leetcode.com/problems/min-stack/
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
    /// 150. Evaluate Reverse Polish Notation
    /// https://leetcode.com/problems/evaluate-reverse-polish-notation/
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

    #region + GenerateParenthesis

    /// <summary>
    /// 22. Generate Parentheses
    /// https://leetcode.com/problems/generate-parentheses/
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();

        Stack<char> stack = new Stack<char>();

        Rec(0, 0);
        return result;

        void Rec(int open, int close)
        {
            if (open == close && open == n && close == n)
            {
                result.Add(string.Join(string.Empty, stack.Reverse()));
                return;
            }

            if (open < n)
            {
                stack.Push('(');
                Rec(open + 1, close);
                stack.Pop();
            }

            if (open > close)
            {
                stack.Push(')');
                Rec(open, close + 1);
                stack.Pop();
            }
        }
    }

    #endregion

    #region + DailyTemperatures

    /// <summary>
    /// 739. Daily Temperatures
    /// https://leetcode.com/problems/daily-temperatures/
    /// </summary>
    /// <param name="temperatures"></param>
    /// <returns></returns>
    public int[] DailyTemperatures(int[] temperatures)
    {
        if (temperatures.Length <= 1)
            return new[] { 0 };
        int[] result = new int[temperatures.Length];

        Stack<int> stackIndices = new Stack<int>();

        for (int right = 0; right < temperatures.Length; right++)
        {
            while (stackIndices.Count > 0 && temperatures[right] > temperatures[stackIndices.Peek()])
            {
                var indexNumber = stackIndices.Pop();
                result[indexNumber] = right - indexNumber;
            }

            stackIndices.Push(right);
        }

        return result;
    }

    #endregion

    #region + CarFleet

    /// <summary>
    /// 853. Car Fleet
    /// https://leetcode.com/problems/car-fleet/
    /// </summary>
    /// <param name="target"></param>
    /// <param name="position"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public int CarFleet(int target, int[] position, int[] speed)
    {
        Array.Sort(position, speed);

        float latestArrival = -1;
        var fleets = 0;
        for (int right = position.Length - 1; right >= 0; right--)
        {
            float time = (target - position[right]) / (float)speed[right];

            if (fleets == 0)
            {
                latestArrival = time;
                fleets++;
            }

            if (time > latestArrival)
            {
                latestArrival = time;
                fleets++;
            }
        }

        return fleets;
    }

    #endregion
}