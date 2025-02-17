﻿namespace AOC.Solvers.Solutions._2024;

public class Day1 : Solver
{
    public override short Year => 2024;
    public override short Day => 01;

    public override int SolvePart1()
    {
        var (left, right) = ParseInput();
        left.Sort();
        right.Sort();
        return left.Zip(right).Aggregate(0, (i, values) => i += Math.Abs(values.First - values.Second));
    }

    public override int SolvePart2()
    {
        var (left, right) = ParseInput();
        return left.Sum(number => number * right.Count(x => x == number));
    }

    private (List<int> Left, List<int> Right) ParseInput()
    {
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in InputProvider.LineByLine(Year, Day))
        {
            var nums = line.Split(" ").Where(x => x != "").ToArray();
            left.Add(int.Parse(nums.First()));
            right.Add(int.Parse(nums.Last()));
        }

        return (left, right);
    }
}
