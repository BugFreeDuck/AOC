namespace AOC.Solutions._2024;

public class Day1 : Solution
{
    public override short Year => 2024;
    public override short Day => 01;

    public override int SolvePart1()
    {
        var (left, right) = ParseInput().Result;
        left.Sort();
        right.Sort();
        return left.Zip(right).Aggregate(0, (i, values) => i += Math.Abs(values.First - values.Second));
    }

    public override int SolvePart2()
    {
        var (left, right) = ParseInput().Result;
        return left.Sum(number => number * right.Count(x => x == number));
    }

    private async Task<(List<int> Left, List<int> Right)> ParseInput()
    {
        var left = new List<int>();
        var right = new List<int>();

        using var sr = new StringReader(await InputProvider.Get(Year, Day));
        while (await sr.ReadLineAsync() is { } line)
        {
            var nums = line.Split(" ").Where(x => x != "").ToArray();
            left.Add(int.Parse(nums.First()));
            right.Add(int.Parse(nums.Last()));
        }

        return (left, right);
    }
}
