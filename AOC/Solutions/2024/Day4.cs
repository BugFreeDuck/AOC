using System.Numerics;

namespace AOC.Solvers.Solutions._2024;

public class Day4 : Solver
{
    public override short Year => 2024;
    public override short Day => 04;

    private static readonly char[] LookFor = ['X', 'M', 'A', 'S'];
    private static readonly char[] LookForReverse = ['S', 'A', 'M', 'X'];

    public override int SolvePart1()
    {
        var matrix = InputProvider.CharMatrix(Year, Day);

        var found = 0;
        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'X')
                {
                    found += FindXmas(matrix, row, col);
                }
            }
        }

        return found;
    }

    private static int FindXmas(char[,] matrix, int row, int col)
    {
        var top = row > 4 ?                        IterateBetween(matrix, row, col, row - 3, col) : [];
        var down = matrix.GetLength(1) - row > 4 ? IterateBetween(matrix, row, col, row + 3, col) : [];

        return IsXmas(down);
    }

    private static int IsXmas(char[] word)
        => (word.SequenceEqual(LookFor) || word.SequenceEqual(LookForReverse)) ? 1 : 0;

    private static char[] IterateBetween(char[,] matrix, int row, int col, int toRow, int toCol)
    {
        var rowDiff = toRow - row;
        var colDiff = toCol - col;

        var chars = new List<char>();
        do
        {
            chars.Add(matrix[row + rowDiff,col + colDiff]);

            // TODO: Check for both way boundaries correctly
            if (rowDiff != 0) rowDiff--;
            if (colDiff != 0) colDiff--;
        } while (rowDiff != 0 || colDiff != 0);

        chars.Add(matrix[row, col]);

        return chars.ToArray();
    }

    // private (int x, int y) GetCoordinatesSafe(char[,] matrix, int x, int y)
    // {
    //     var a = matrix.GetValue(x, y);
    // }

    public override int SolvePart2()
    {
        return 0;
    }
}
