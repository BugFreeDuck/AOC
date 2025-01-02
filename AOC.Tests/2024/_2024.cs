using AOC.Solvers.Solutions._2024;

namespace AOC.Tests._2024;

[TestFixture]
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

        RunFullTest(new Day1(), testInput, expectedPart1, expectedPart2);
    }

    [Test]
    public void Day02()
    {
        const int expectedPart1 = 2;
        const int expectedPart2 = 4;
        const string testInput =
            """
            7 6 4 2 1
            1 2 7 8 9
            9 7 6 2 1
            1 3 2 4 5
            8 6 4 4 1
            1 3 6 7 9
            """;

        RunFullTest(new Day2(), testInput, expectedPart1, expectedPart2);
    }

    public class Day03 : AocTestBase
    {
        [Test]
        public void Day03_Part1()
        {
            const int expectedResult = 161;
            const string testInput =  "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

            RunTest(new Day3(), solver => solver.SolvePart1(), testInput, expectedResult);
        }

        [Test]
        public void Day03_Part2()
        {
            const int expectedResult = 48;
            const string testInput =  "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

            RunTest(new Day3(), solver => solver.SolvePart2(), testInput, expectedResult);
        }
    }

    [Test]
    public void Day04()
    {
        const int expectedPart1 = 18;
        const string testInput =
            """
            MMMSXXMASM
            MSAMXMSMSA
            AMXSXMAAMM
            MSAMASMSMX
            XMASAMXAMM
            XXAMMXXAMA
            SMSMSASXSS
            SAXAMASAAA
            MAMMMXMMMM
            MXMXAXMASX
            """;

        RunTest(new Day4(), solver => solver.SolvePart1(), testInput, expectedPart1);
    }
}
