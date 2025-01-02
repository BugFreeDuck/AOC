namespace AOC.Solvers.Solutions._2024;

public class Day3 : Solver
{
    public override short Year => 2024;
    public override short Day => 03;

    public override int SolvePart1()
    {
        var mask = "mul(X,Y)";
        var maskIdx = 0;

        var x = 0;
        var y = 0;
        var result = 0;
        foreach (var c in InputProvider.CharByChar(Year, Day))
        {
            var mulValue = FindMul(c, mask, ref maskIdx, ref x, ref y);
            result += mulValue;
        }

        return result;
    }

    public override int SolvePart2()
    {
        var mask = "mul(X,Y)";
        var maskIdx = 0;

        var doMask = "do()";
        var doMaskIdx = 0;
        var dontMask = "don't()";
        var dontMaskIdx = 0;
        var isInDo = true;

        var x = 0;
        var y = 0;
        var result = 0;
        foreach (var c in InputProvider.CharByChar(Year, Day))
        {
            if (FindCondition(c, doMask, ref doMaskIdx))
            {
                isInDo = true;
            };
            if (FindCondition(c, dontMask, ref dontMaskIdx))
            {
                isInDo = false;
            }

            if (isInDo)
            {
                var mulValue = FindMul(c, mask, ref maskIdx, ref x, ref y);
                result += mulValue;
            }
        }

        return result;
    }

    private int FindMul(char c, string mask, ref int maskIdx, ref int x, ref int y)
    {
        var lookFor = mask[maskIdx];
        if (c == lookFor)
        {
            maskIdx++;
        }
        else if (lookFor == 'X' && char.IsDigit(c))
        {
            x = (x * 10) + int.Parse(c.ToString());
        }
        else if (lookFor == 'X' && c == ',')
        {
            maskIdx += 2;
        }
        else if (lookFor == 'Y' && char.IsDigit(c))
        {
            y = (y * 10) + int.Parse(c.ToString());
        }
        else if (lookFor == 'Y' && c == ')')
        {
            var result = x * y;
            x = 0;
            y = 0;
            maskIdx = 0;
            return result;
        }
        else
        {
            x = 0;
            y = 0;
            maskIdx = 0;
        }

        return 0;
    }

    private static bool FindCondition(char c, string conditionMask, ref int conditionIdx)
    {
        var lookFor = conditionMask[conditionIdx];

        conditionIdx = c == lookFor ? conditionIdx + 1 : 0;

        if (conditionMask.Length - 1 != conditionIdx)
        {
            return false;
        }

        conditionIdx = 0;
        return true;
    }
}
