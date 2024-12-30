using AOC.Solutions._2024;

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
}
