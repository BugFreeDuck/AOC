namespace AOC.Solvers;

public abstract class Solver
{
    public abstract short Year { get; }
    public abstract short Day { get; }

    private IInputProvider? _inputProvider;

    public IInputProvider InputProvider
    {
        get => _inputProvider ?? throw new Exception("Input provider is not set");
        set => _inputProvider = value;
    }

    public abstract int SolvePart1();
    public abstract int SolvePart2();
}
