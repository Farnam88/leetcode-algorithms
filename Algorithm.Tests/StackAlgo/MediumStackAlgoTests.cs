﻿using FluentAssertions;

namespace Algorithm.Tests.StackAlgo;

public class MediumStackAlgoTests
{
    private readonly MediumStackAlgo _sut;

    public MediumStackAlgoTests()
    {
        _sut = new MediumStackAlgo();
    }

    #region + MinStackOperationTest

    [Theory]
    [InlineData(new int[] { -2, 0, -3 }, new int[] { -3, -2 })]
    [InlineData(new int[] { -3, -2, 0 }, new int[] { -3, -3 })]
    [InlineData(new int[] { 3, 5, -1 }, new int[] { -1, 3 })]
    public void MinStackOperationTest(int[] input, int[] expected)
    {
        var result = _sut.MinStackOperation(input);
        Assert.Equal(expected, result);
    }

    #endregion

    #region + EvalRPNTest

    [Theory]
    [InlineData(new string[] { "18" }, 18)]
    [InlineData(new string[] { "2", "1", "+", "3", "*" }, 9)]
    [InlineData(new string[] { "4", "13", "5", "/", "+" }, 6)]
    [InlineData(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
    public void EvalRPNTest(string[] tokens, int expectd)
    {
        var result = _sut.EvalRPN(tokens);
        Assert.Equal(expectd, result);
    }

    #endregion

    #region + GenerateParenthesis

    [Theory]
    [MemberData(nameof(GenerateParenthesisData))]
    public void GenerateParenthesis(int n, List<string> expected)
    {
        var result = _sut.GenerateParenthesis(n);

        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> GenerateParenthesisData =>
        new List<object[]>
        {
            new object[]
            {
                3,
                new List<string>
                {
                    "((()))", "(()())", "(())()", "()(())", "()()()"
                }
            },
            new object[]
            {
                1,
                new List<string>
                {
                    "()"
                }
            },
            new object[]
            {
                2,
                new List<string>
                {
                    "()()", "(())"
                }
            }
        };

    #endregion

    #region + DailyTemperaturesTest

    [Theory]
    [InlineData(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new int[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    [InlineData(new int[] { 30, 40, 50, 60 }, new int[] { 1, 1, 1, 0 })]
    [InlineData(new int[] { 30, 60, 90 }, new int[] { 1, 1, 0 })]
    [InlineData(new int[] { 89, 62, 70, 58, 47, 47, 46, 76, 100, 70 }, new int[] { 8, 1, 5, 4, 3, 2, 1, 1, 0, 0 })]
    public void DailyTemperaturesTest(int[] temperatures, int[] expected)
    {
        var result = _sut.DailyTemperatures(temperatures);

        result.Should().BeEquivalentTo(expected);
    }

    #endregion

    #region + CarFleetTest

    [Theory]
    [InlineData(12, new int[] { 10, 8, 0, 5, 3 }, new int[] { 2, 4, 1, 1, 3 }, 3)]
    [InlineData(10, new int[] { 3 }, new int[] { 3 }, 1)]
    [InlineData(100, new int[] { 0, 2, 4 }, new int[] { 4, 2, 1 }, 1)]
    public void CarFleetTest(int target, int[] position, int[] speed, int expected)
    {
        var result = _sut.CarFleet(target, position, speed);

        Assert.Equal(expected, result);
    }

    #endregion
}