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
            var part1 = solver.SolvePart1();
            var part2 = solver.SolvePart2();
            Assert.That(part1, Is.EqualTo(expectedPart1));
            TestContext.Out.WriteLine($"[TEST] Part 1 result: {part1}");
            Assert.That(part2, Is.EqualTo(expectedPart2));
            TestContext.Out.WriteLine($"[TEST] Part 2 result: {part2}");

            solver.InputProvider = _inputProvider;
            TestContext.Out.WriteLine($"Part 1 result: {solver.SolvePart1()}");
            TestContext.Out.WriteLine($"Part 2 result: {solver.SolvePart2()}");
        });
    }
}
