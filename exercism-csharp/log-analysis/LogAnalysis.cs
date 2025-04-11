public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string div) => str.Split(div)[1];

    public static string SubstringBetween(this string str, string div1, string div2)
    {
        int start = str.IndexOf(div1) + div1.Length;
        int length = str.IndexOf(div2) - start;
        return str.Substring(start, length);
    }

    public static string Message(this string str) => str.Split(":")[1].Trim();

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}

