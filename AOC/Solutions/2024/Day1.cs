using System;
using System.Collections.Generic;
using System.Linq;
using AOC.Input;

namespace AOC.Solutions._2024;

public class Day1 : Solution
{
    public override short Year => 2024;
    public override short Day => 01;

    public Day1(IInputProvider inputProvider) : base(inputProvider) { }

    public override int SolvePart1()
    {
        var input = InputProvider.Get(Year, Day).Result;

        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in input.Split(Environment.NewLine))
        {
            var nums = line.Split(" ");
            left.Add(int.Parse(nums[0]));
            right.Add(int.Parse(nums[1]));
        }

        left.Sort();
        right.Sort();

        return left.Zip(right).Aggregate(0, (i, values) => i += Math.Abs(values.First - values.Second));
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }
}
