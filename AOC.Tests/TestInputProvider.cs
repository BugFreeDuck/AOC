using AOC.Solvers;

namespace AOC.Tests;

public class TestInputProvider : IInputProvider
{
    private readonly string _input;

    public TestInputProvider(string input)
    {
        _input = input;
    }

    public IEnumerable<string> LineByLine(short year, short day)
    {
        return _input.Split(Environment.NewLine);
    }

    public IEnumerable<char> CharByChar(short year, short day)
    {
        return _input;
    }

    public char[,] CharMatrix(short year, short day)
    {
        var lines = _input.Split(Environment.NewLine).ToArray();
        var lineLength = lines.First().Length;

        var matrix = new char[lines.Length, lineLength];
        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lineLength; j++)
            {
                matrix[i, j] = lines[i][j];
            }
        }

        return matrix;
    }
}
