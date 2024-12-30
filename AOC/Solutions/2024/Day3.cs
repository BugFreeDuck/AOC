namespace AOC.Solvers.Solutions._2024;

public class Day3 : Solver
{
    public override short Year => 2024;
    public override short Day => 03;

    private const int bufSize = 15;

    //179571322
    public override int SolvePart1()
    {
        var input = InputProvider.CharByChar(Year, Day);

        var result = 0;
        var buffer = new char[bufSize];
        var bufferIdx = 0;
        var mask = "mul(X,Y)";
        var maskIdx = 0;

        foreach (var c in input)
        {
            if (FindMul(c, buffer, mask, ref bufferIdx, ref maskIdx))
            {
                var numbers = new string(buffer).Split('(', ')', ',').Skip(1).ToArray();
                result += int.Parse(numbers.First()) * int.Parse(numbers.Last());
                buffer = new char[bufSize];
                bufferIdx = 0;
                maskIdx = 0;
            }
        }

        // foreach (var c in input)
        // {
        //     var lookFor = mask[maskIdx];
        //     if (c == lookFor)
        //     {
        //         buffer[bufferIdx++] = c;
        //         maskIdx++;
        //     }
        //     else if ((lookFor == 'X' || lookFor == 'Y') && char.IsDigit(c))
        //     {
        //         buffer[bufferIdx++] = c;
        //     }
        //     else if (lookFor == 'X' && c == ',')
        //     {
        //         buffer[bufferIdx++] = c;
        //         maskIdx += 2;
        //     }
        //     else if (lookFor == 'Y' && c == ')')
        //     {
        //         var numbers = new string(buffer).Split('(', ')', ',').Skip(1).ToArray();
        //         result += int.Parse(numbers.First()) * int.Parse(numbers.Last());
        //         buffer = new char[bufSize];
        //         bufferIdx = 0;
        //         maskIdx = 0;
        //     }
        //     else if (buffer.Any(x => x == '\0'))
        //     {
        //         buffer = new char[bufSize];
        //         bufferIdx = 0;
        //         maskIdx = 0;
        //     }
        // }

        return result;
    }

    private bool FindMul(char c, char[] buffer, string mask, ref int maskIdx, ref int bufferIdx)
    {
        var lookFor = mask[maskIdx];
        if (c == lookFor)
        {
            buffer[bufferIdx++] = c;
            maskIdx++;
        }
        else if ((lookFor == 'X' || lookFor == 'Y') && char.IsDigit(c))
        {
            buffer[bufferIdx++] = c;
        }
        else if (lookFor == 'X' && c == ',')
        {
            buffer[bufferIdx++] = c;
            maskIdx += 2;
        }
        else if (lookFor == 'Y' && c == ')')
        {
            return true;
        }
        else if (buffer.Any(x => x == '\0'))
        {
            buffer = new char[bufSize];
            bufferIdx = 0;
            maskIdx = 0;
        }

        return false;
    }

    public override int SolvePart2()
    {
        return 0;
    }
}
