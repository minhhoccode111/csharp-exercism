using System;

public static class LogAnalysis
{
    // public string SubstringAfter() // this cause the error below
    // LogAnalysis.cs|5 col 19-33 error| 'SubstringAfter': cannot declare instance members in a static class

    public static string SubstringAfter(this string current, string sub)
    {
        int indexOfSub = current.IndexOf(sub);
        return current.Substring(indexOfSub + sub.Length);
    }

    public static string SubstringBetween(this string current, string startStr, string endStr)
    {
        int startIndex = current.IndexOf(startStr) + startStr.Length;
        int endIndex = current.IndexOf(endStr);

        return current.Substring(startIndex, endIndex - startIndex);
    }

    public static string Message(this string current)
    {
        return current.SubstringAfter(":").Trim();
    }

    public static string LogLevel(this string current)
    {
        // reuse method above
        return current.SubstringBetween("[", "]");
    }
}

