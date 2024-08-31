using System;

public static class SimpleCalculator
{
    public static string Calculate(int o1, int o2, string operation) =>
        operation switch
        {
            "+" => $"{o1} + {o2} = {o1 + o2}",
            "*" => $"{o1} * {o2} = {o1 * o2}",
            "/" => o2 == 0 ? "Division by zero is not allowed." : $"{o1} / {o2} = {o1 / o2}",
            "" => throw new ArgumentException(),
            null => throw new ArgumentNullException(),
            _ => throw new ArgumentOutOfRangeException(),
        };
}
