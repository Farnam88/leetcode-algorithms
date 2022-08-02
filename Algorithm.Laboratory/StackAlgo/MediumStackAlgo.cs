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
}