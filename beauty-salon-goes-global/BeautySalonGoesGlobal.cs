using System;
using System.Collections.Generic;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris,
}

public enum AlertLevel
{
    Early,
    Standard,
    Late,
}

public static class Appointment
{
    private static readonly Dictionary<Location, (string windows, string linux)> dict =
        new Dictionary<Location, (string, string)>
        {
            { Location.NewYork, ("Eastern Standard Time", "America/New_York") },
            { Location.Paris, ("W. Europe Standard Time", "Europe/Paris") },
            { Location.London, ("GMT Standard Time", "Europe/London") },
        };

    private static string GetId(Location location)
    {
        if (dict.TryGetValue(location, out var timeZoneId))
        {
            if (OperatingSystem.IsWindows())
            {
                return timeZoneId.windows;
            }
            return timeZoneId.linux;
        }

        throw new ArgumentException();
    }

    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string dtStr, Location location)
    {
        DateTime localDateTime = DateTime.ParseExact(
            dtStr,
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture
        );

        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));

        return TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Late => appointment.AddMinutes(-30),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Early => appointment.AddMinutes(-(60 * 24)),
            _ => throw new ArgumentException(),
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime sevenDaysAgo = dt.AddDays(-7);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));

        bool isDstNow = timeZoneInfo.IsDaylightSavingTime(dt);
        bool isDstSevenDaysAgo = timeZoneInfo.IsDaylightSavingTime(sevenDaysAgo);
        return isDstNow != isDstSevenDaysAgo;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        if (location == Location.NewYork)
        {
            try
            {
                return DateTime.ParseExact(
                    dtStr,
                    "M/d/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture
                );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        return DateTime.ParseExact(dtStr, "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    }
}
