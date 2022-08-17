namespace Algorithm.Laboratory.LinkedListAlgo;

/// <summary>
/// 146. LRU Cache
/// https://leetcode.com/problems/lru-cache/
/// </summary>
public class LRUCache
{
    private int _capacity;
    private readonly Dictionary<int, InternalNode> _cache;

    /// <summary>
    /// Right pointer
    /// </summary>
    private InternalNode _rightDummy;

    /// <summary>
    /// Left Pointer
    /// </summary>
    private InternalNode _leftDummy;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new();
        _rightDummy = new InternalNode(0, 0);
        _leftDummy = new InternalNode(0, 0);
        _leftDummy.Next = _rightDummy;
        _rightDummy.Previous = _leftDummy;
    }

    public int Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            var recentlyUsed = _cache[key];
            Remove(recentlyUsed);
            Insert(recentlyUsed);
            return recentlyUsed.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
            Remove(_cache[key]);
        _cache.TryAdd(key, null);
        _cache[key] = new InternalNode(key, value);
        Insert(_cache[key]);
        if (_cache.Count > _capacity)
        {
            var leastRecentlyUsed = _leftDummy.Next;
            Remove(leastRecentlyUsed);
            _cache.Remove(leastRecentlyUsed.Key);
        }
    }

    private void Remove(InternalNode node)
    {
        var prev = node.Previous;
        var next = node.Next;
        prev.Next = next;
        next.Previous = prev;
    }

    private void Insert(InternalNode node)
    {
        var rightDummy = _rightDummy;
        var previousMostRecentlyUsed = _rightDummy.Previous;
        rightDummy.Previous = node;
        previousMostRecentlyUsed.Next = node;
        node.Next = rightDummy;
        node.Previous = previousMostRecentlyUsed;
    }

    private class InternalNode
    {
        public int Key;
        public int Value;
        public InternalNode Previous;
        public InternalNode Next;

        public InternalNode(int key, int value)
        {
            Key = key;
            Value = value;
            Previous = null;
            Next = null;
        }
    }
}