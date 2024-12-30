namespace AOC.Solvers;

public interface IInputProvider
{
    IEnumerable<string> LineByLine(short year, short day);
}
