namespace AOC.Solvers.Solutions._2024;

public class Day2 : Solver
{
    public override short Year => 2024;
    public override short Day => 02;

    public override int SolvePart1()
    {
        var reports = InputProvider.LineByLine(Year, Day);
        return reports.Count(report => IsSafe(ParseReport(report)));
    }

    // 700 - too low
    public override int SolvePart2()
    {
        var reports = InputProvider.LineByLine(Year, Day).ToArray();
        return reports.Count(IsSafeDampen);
    }

    private static int[] ParseReport(string report)
        => report.Split(' ').Select(int.Parse).ToArray();


    private static bool IsSafe(int[] values)
    {
        var isAsc = true;
        var isDesc = true;
        var isSafeDiff = true;

        for (var i = 1; i < values.Length; i++)
        {
            var prior = values[i - 1];
            var current = values[i];

            if (prior < current)
                isDesc = false;
            else if (current < prior)
                isAsc = false;
            else
            {
                isSafeDiff = false;
                break;
            }

            if (!(Math.Abs(prior - current) >= 1 && Math.Abs(prior - current) <= 3))
            {
                isSafeDiff = false;
                break;
            }
        }

        return (isAsc || isDesc) && isSafeDiff;
    }

    private static bool IsSafeDampen(string report)
    {
        var values = ParseReport(report).ToList();

        for (var i = 0; i < values.Count; i++)
        {
            var testValues = new List<int>(values);
            testValues.RemoveAt(i);

            if(IsSafe(testValues.ToArray()))
            {
                return true;
            }
        }

        return false;
    }
}
