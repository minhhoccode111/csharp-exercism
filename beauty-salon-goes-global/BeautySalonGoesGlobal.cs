using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

// TODO: do this
public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localTime = DateTime.Parse(
            appointmentDateDescription,
            CultureInfo.InvariantCulture
        );
        TimeZoneInfo timeZone = GetTimeZoneInfo(location);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentException("Invalid alert level")
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZoneInfo(location);
        DateTime sevenDaysAgo = dt.AddDays(-7);

        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(sevenDaysAgo);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string format = location == Location.NewYork ? "M/d/yyyy HH:mm:ss" : "dd/MM/yyyy HH:mm:ss";
        if (
            DateTime.TryParseExact(
                dtStr,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime result
            )
        )
        {
            return result;
        }
        return new DateTime(1, 1, 1);
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        string timeZoneId =
            Environment.OSVersion.Platform == PlatformID.Win32NT
                ? GetWindowsTimeZoneId(location)
                : GetUnixTimeZoneId(location);

        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    private static string GetWindowsTimeZoneId(Location location)
    {
        return location switch
        {
            Location.NewYork => "Eastern Standard Time",
            Location.London => "GMT Standard Time",
            Location.Paris => "W. Europe Standard Time",
            _ => throw new ArgumentException("Invalid location")
        };
    }

    private static string GetUnixTimeZoneId(Location location)
    {
        return location switch
        {
            Location.NewYork => "America/New_York",
            Location.London => "Europe/London",
            Location.Paris => "Europe/Paris",
            _ => throw new ArgumentException("Invalid location")
        };
    }
}
