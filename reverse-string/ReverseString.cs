using System;

public static class ReverseString
{
    // add char by char
    public static string _Reverse(string input)
    {
        string result = "";
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            result = c + result;
        }
        return result;
    }

    // recursive
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        return Reverse(input.Substring(1)) + input[0];
    }
}

