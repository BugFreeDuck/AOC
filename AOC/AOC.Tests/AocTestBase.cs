using AOC.Input;

namespace AOC.Tests;

public class AocTestBase
{
    private readonly InputProvider _inputProvider;

    protected AocTestBase()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://adventofcode.com");
        client.DefaultRequestHeaders.Add("Cookie", Environment.GetEnvironmentVariable("AOC_TOKEN"));
        _inputProvider = new InputProvider(client);
    }

    protected void RunTest(Solution solution, string testInput, int expectedPart1, int expectedPart2)
    {
        Assert.Multiple(() =>
        {
            solution.InputProvider = new TestInputProvider(testInput);
            Assert.That(solution.SolvePart1(), Is.EqualTo(expectedPart1));
            Assert.That(solution.SolvePart2(), Is.EqualTo(expectedPart2));

            solution.InputProvider = _inputProvider;
            TestContext.Out.WriteLine($"Part 1 result: {solution.SolvePart1()}");
            TestContext.Out.WriteLine($"Part 2 result: {solution.SolvePart2()}");
        });
    }
}
