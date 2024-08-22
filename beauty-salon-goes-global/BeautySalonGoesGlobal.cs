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
        new Dictionary<Location, (string windows, string linux)>
        {
            { Location.NewYork, ("Eastern Standard Time", "America/New_York") },
            { Location.London, ("GMT Standard Time", "Europe/London") },
            { Location.Paris, ("W. Europe Standard Time", "Europe/Paris") },
        };

    private static string GetId(Location location)
    {
        if (!dict.TryGetValue(location, out var value))
        {
            throw new ArgumentException();
        }

        if (OperatingSystem.IsWindows())
        {
            return value.windows;
        }
        return value.linux;
    }

    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string dtStr, Location location)
    {
        DateTime dtUtc = DateTime.ParseExact(
            dtStr,
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));

        return TimeZoneInfo.ConvertTimeFromUtc(dtUtc, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        throw new NotImplementedException(
            "Please implement the (static) Appointment.GetAlertTime() method"
        );
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        throw new NotImplementedException(
            "Please implement the (static) Appointment.HasDaylightSavingChanged() method"
        );
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        throw new NotImplementedException(
            "Please implement the (static) Appointment.NormalizeDateTime() method"
        );
    }
}
