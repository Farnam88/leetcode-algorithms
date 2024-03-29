﻿using Microsoft.VisualBasic;

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

        return new int[] {firstMin, secondMin};
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
        Stack<int> stack = new();
        for (int right = 0; right < tokens.Length; right++)
        {
            var token = tokens[right];
            if (int.TryParse(token, out int currentNumber))
            {
                stack.Push(currentNumber);
                continue;
            }

            (int Last, int First) items = new(stack.Pop(), stack.Pop());
            switch (token)
            {
                case "+":
                    stack.Push(items.First + items.Last);
                    break;
                case "-":
                    stack.Push(items.First - items.Last);
                    break;
                case "*":
                    stack.Push(items.First * items.Last);
                    break;
                case "/":
                    stack.Push(items.First / items.Last);
                    break;
            }
        }

        return stack.Pop();
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
        Stack<char> stack = new();
        List<string> result = new();
        
        Recursion(0, 0);
        
        return result;

        void Recursion(int open, int close)
        {
            if (open == close && open == n && close == n)
            {
                result.Add(string.Join("", stack.Reverse()));
                return;
            }

            if (open < n)
            {
                stack.Push('(');
                Recursion(open + 1, close);
                stack.Pop();
            }

            if (open > close)
            {
                stack.Push(')');
                Recursion(open, close + 1);
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
            return new[] {0};
        int[] result = new int[temperatures.Length];
        Stack<int> stack = new();
        for (int right = 0; right < temperatures.Length; right++)
        {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[right])
            {
                var index = stack.Pop();
                result[index] = right - index;
            }
            stack.Push(right);
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
        Array.Sort(position,speed);
        int fleet = 0;
        float slowest = -1;
        for (int i = position.Length - 1; i >= 0; i--)
        {
            var currentArriveTime = (target - position[i]) / (float)speed[i];
            if (currentArriveTime > slowest)
            {
                fleet++;
                slowest = currentArriveTime;
            }
        }

        return fleet;
    }

    #endregion
}