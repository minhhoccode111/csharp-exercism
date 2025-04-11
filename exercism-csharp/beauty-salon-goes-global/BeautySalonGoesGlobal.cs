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
            return OperatingSystem.IsWindows() ? timeZoneId.windows : timeZoneId.linux;
        }
        throw new ArgumentException($"Unsupported location: {location}");
    }

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string dtStr, Location location)
    {
        var localDateTime = DateTime.ParseExact(
            dtStr,
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture
        );
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));
        return TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Late => appointment.AddMinutes(-30),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Early => appointment.AddMinutes(-1440),
            _ => throw new ArgumentException($"Unsupported alert level: {alertLevel}"),
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));
        var sevenDaysAgo = dt.AddDays(-7);
        return timeZoneInfo.IsDaylightSavingTime(dt)
            != timeZoneInfo.IsDaylightSavingTime(sevenDaysAgo);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var format = location == Location.NewYork ? "M/d/yyyy HH:mm:ss" : "d/M/yyyy HH:mm:ss";

        return DateTime.TryParseExact(
            dtStr,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var result
        )
            ? result
            : DateTime.MinValue;
    }
}
