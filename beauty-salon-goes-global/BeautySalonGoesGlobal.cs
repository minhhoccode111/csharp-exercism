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
        DateTime dtLocal = DateTime.ParseExact(
            dtStr,
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture
        );

        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));

        return TimeZoneInfo.ConvertTimeToUtc(dtLocal, timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddHours(-1).AddMinutes(-45);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
            default:
                throw new ArgumentException("Invalid alert level", nameof(alertLevel));
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetId(location));
        DateTime start = dt.AddDays(-7);
        DateTime end = dt;

        bool startDST = timeZone.IsDaylightSavingTime(start);
        bool endDST = timeZone.IsDaylightSavingTime(end);

        return startDST != endDST;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string format;
        CultureInfo culture;

        switch (location)
        {
            case Location.NewYork:
                format = "M/d/yyyy HH:mm:ss";
                culture = new CultureInfo("en-US");
                break;
            case Location.London:
            case Location.Paris:
                format = "dd/MM/yyyy HH:mm:ss";
                culture = new CultureInfo(location == Location.London ? "en-GB" : "fr-FR");
                break;
            default:
                throw new ArgumentException("Invalid location", nameof(location));
        }

        if (
            DateTime.TryParseExact(dtStr, format, culture, DateTimeStyles.None, out DateTime result)
        )
        {
            return result;
        }
        return new DateTime(1, 1, 1, 0, 0, 0);
    }
}
