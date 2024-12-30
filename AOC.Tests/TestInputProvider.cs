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
}
