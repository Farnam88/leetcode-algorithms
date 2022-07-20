using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Algorithm.Laboratory;

namespace Algorithm.ConApp;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Benchy
{
    private readonly int[] _nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
    private readonly int[] _numsLong = Enumerable.Range(1, 1000).Select(s => s = new Random().Next(0, 1000)).ToArray();

    public Benchy()
    {
    }

    [Benchmark]
    public void First()
    {
    }

    [Benchmark]
    public void Second()
    {
    }

    [Benchmark]
    public void Third()
    {
    }

    [Benchmark]
    public void Fourth()
    {
    }
}