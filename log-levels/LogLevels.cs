using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Split(':')[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        string str = logLine.Split(':')[0].Trim();
        if (str == "[INFO]")
        {
            return "info";
        }

        if (str == "[ERROR]")
        {
            return "error";
        }

        if (str == "[WARNING]")
        {
            return "warning";
        }

        return "";
    }

    public static string Reformat(string logLine)
    {
        string logLevel = LogLevel(logLine);
        string message = Message(logLine);
        return $"{message} ({logLevel})";
    }
}
