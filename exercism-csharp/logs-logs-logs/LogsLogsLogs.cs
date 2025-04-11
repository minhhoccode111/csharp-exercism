using System;

// TODO: define the 'LogLevel' enum

enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        if (logLine.Contains("TRC"))
            return LogLevel.Trace;
        if (logLine.Contains("DBG"))
            return LogLevel.Debug;
        if (logLine.Contains("INF"))
            return LogLevel.Info;
        if (logLine.Contains("WRN"))
            return LogLevel.Warning;
        if (logLine.Contains("ERR"))
            return LogLevel.Error;
        if (logLine.Contains("FTL"))
            return LogLevel.Fatal;
        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        logLevel switch
        {
            LogLevel.Unknown => $"0:{message}",
            LogLevel.Trace => $"1:{message}",
            LogLevel.Debug => $"2:{message}",
            LogLevel.Info => $"4:{message}",
            LogLevel.Warning => $"5:{message}",
            LogLevel.Error => $"6:{message}",
            LogLevel.Fatal => $"42:{message}",
            _ => string.Empty,
        };
}
