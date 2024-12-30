using AOC.Solvers.Solutions._2024;

namespace AOC.Tests._2024;

public class _2024 : AocTestBase
{
    [Test]
    public void Day01()
    {
        const int expectedPart1 = 11;
        const int expectedPart2 = 31;
        const string testInput =
            """
            3   4
            4   3
            2   5
            1   3
            3   9
            3   3
            """;

        RunTest(new Day1(), testInput, expectedPart1, expectedPart2);
    }

    [Test]
    public void Day02()
    {
        const int expectedPart1 = 2;
        const int expectedPart2 = 0;
        const string testInput =
            """
            7 6 4 2 1
            1 2 7 8 9
            9 7 6 2 1
            1 3 2 4 5
            8 6 4 4 1
            1 3 6 7 9
            """;

        RunTest(new Day2(), testInput, expectedPart1, expectedPart2);
    }
}
