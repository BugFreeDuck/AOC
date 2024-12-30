using AOC.Input;
using AOC.Solutions._2024;

namespace AOC.AOC.Tests._2024;

public class _2024
{
    [Fact]
    public void Test_2024_Day01()
    {
        var inputProvider = new TestInputProvider(
            """
            3   4
            4   3
            2   5
            1   3
            3   9
            3   3
            """
        );

        var solver = new Day1(inputProvider);
        var result = solver.SolvePart1();

        Assert.Equal(11, result);
    }
}
