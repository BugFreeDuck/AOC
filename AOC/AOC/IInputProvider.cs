namespace AOC.Solvers;

public interface IInputProvider
{
    Task<string> Get(short year, short day);
    IAsyncEnumerable<string> LineByLine(short year, short day);
}
