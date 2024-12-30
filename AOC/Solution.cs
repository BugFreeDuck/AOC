using AOC.Input;

namespace AOC;

public abstract class Solution
{
    public abstract short Year { get; }
    public abstract short Day { get; }

    protected readonly IInputProvider InputProvider;

    protected Solution(IInputProvider inputProvider)
    {
        InputProvider = inputProvider;
    }

    public abstract int SolvePart1();
    public abstract int SolvePart2();
}
