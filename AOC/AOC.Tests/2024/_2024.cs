using AOC.Input;
using AOC.Solutions._2024;

namespace AOC.AOC.Tests._2024;

public class _2024
{
    private readonly InputProvider _inputProvider;

    public _2024()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://adventofcode.com");
        var cookie = Environment.GetEnvironmentVariable("AOC_TOKEN");
        client.DefaultRequestHeaders.Add("Cookie", cookie);
        _inputProvider = new InputProvider(client);
    }

    [Test]
    public void Day01()
    {
        var testInputProvider = new TestInputProvider(
            """
            3   4
            4   3
            2   5
            1   3
            3   9
            3   3
            """
        );

        var solver = new Day1(testInputProvider);
        var result = solver.SolvePart1();

        TestContext.Out.WriteLine($"Result: {result}");
        Assert.That(result, Is.EqualTo(11));
    }
}
