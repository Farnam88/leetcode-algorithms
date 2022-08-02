namespace Algorithm.Laboratory.StackAlgo;

/// <summary>
/// 155. Min Stack
/// https://leetcode.com/problems/min-stack/
/// </summary>
public class MinStack
{
    private int _count = 0;
    private readonly List<int> _list;
    private readonly List<int> _listMin;

    public MinStack()
    {
        _count = 0;
        _list = new List<int>();
        _listMin = new List<int>();
    }

    public void Push(int val)
    {
        _list.Add(val);
        _count++;
        if (_listMin.Count == 0 || _list[_listMin.Last()] > val)
            _listMin.Add(_count - 1);
    }

    public void Pop()
    {
        if (_count == 0)
            throw new Exception("Stack is empty");

        var index = _count - 1;
        _listMin.Remove(index);
        _list.RemoveAt(index);
        _count--;
    }

    public int Top()
    {
        if (_count == 0)
            throw new Exception("Stack is empty");
        return _list[_count - 1];
    }

    public int GetMin()
    {
        if (_listMin.Count == 0 && _count == 0)
            throw new Exception("Stack is empty");
        return _list[_listMin.Last()];
    }
}