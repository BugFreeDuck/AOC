using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOC.Input;

public class TestInputProvider : IInputProvider
{
    private readonly string _input;

    public TestInputProvider(string input)
    {
        _input = input;
    }

    public Task<string> Get(short year, short day)
    {
        return Task.FromResult(_input);
    }

    public async IAsyncEnumerable<string> LineByLine(short year, short day)
    {
        foreach (var line in _input.Split(Environment.NewLine))
        {
            yield return line;
        }
    }
}
