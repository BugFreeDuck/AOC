using AOC.Solvers;

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

    protected void RunTest(Solver solver, string testInput, int expectedPart1, int expectedPart2)
    {
        Assert.Multiple(() =>
        {
            solver.InputProvider = new TestInputProvider(testInput);
            Assert.That(solver.SolvePart1(), Is.EqualTo(expectedPart1));
            Assert.That(solver.SolvePart2(), Is.EqualTo(expectedPart2));

            solver.InputProvider = _inputProvider;
            TestContext.Out.WriteLine($"Part 1 result: {solver.SolvePart1()}");
            TestContext.Out.WriteLine($"Part 2 result: {solver.SolvePart2()}");
        });
    }
}
