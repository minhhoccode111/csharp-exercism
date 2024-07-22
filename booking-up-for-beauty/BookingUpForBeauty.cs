using System;

static class Appointment
{
    private static int ToNumber(string num)
    {
        return int.Parse(num);
    }

    private static int GetMonth(string month)
    {
        switch (month)
        {
            case "January":
                return 1;
            case "February":
                return 2;
            case "March":
                return 3;
            case "April":
                return 4;
            case "May":
                return 5;
            case "June":
                return 6;
            case "July":
                return 7;
            case "August":
                return 8;
            case "September":
                return 9;
            case "October":
                return 10;
            case "November":
                return 11;
            case "December":
                return 12;
            default:
                return 0;
        }
    }

    public static DateTime Schedule(string date)
    {
        int year,
            month,
            day,
            hour,
            min,
            sec;

        // count comman in string
        int numberOfComma = date.Length - date.Replace(",", "").Length;
        if (numberOfComma == 0)
        {
            string[] splitedString = date.Split(' ');
            string[] splitedDate = splitedString[0].Split('/');
            string[] splitedTime = splitedString[1].Split(':');
            year = ToNumber(splitedDate[2]);
            month = ToNumber(splitedDate[0]);
            day = ToNumber(splitedDate[1]);
            hour = ToNumber(splitedTime[0]);
            min = ToNumber(splitedTime[1]);
            sec = ToNumber(splitedTime[2]);
        }
        else if (numberOfComma == 1)
        {
            string[] splitedString = date.Replace(",", "").Split(' ');
            string[] splitedTime = splitedString[3].Split(':');
            year = ToNumber(splitedString[2]);
            month = GetMonth(splitedString[0]);
            day = ToNumber(splitedString[1]);
            hour = ToNumber(splitedTime[0]);
            min = ToNumber(splitedTime[1]);
            sec = ToNumber(splitedTime[2]);
        }
        else
        {
            string[] splitedString = date.Replace(",", "").Split(' ');
            string[] splitedTime = splitedString[4].Split(':');
            year = ToNumber(splitedString[3]);
            month = GetMonth(splitedString[1]);
            day = ToNumber(splitedString[2]);
            hour = ToNumber(splitedTime[0]);
            min = ToNumber(splitedTime[1]);
            sec = ToNumber(splitedTime[2]);
        }

        return new DateTime(year, month, day, hour, min, sec);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime now = DateTime.Now;

        return DateTime.Compare(now, appointmentDate) > 0;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        TimeSpan input = appointmentDate.TimeOfDay;
        TimeSpan start = new TimeSpan(12, 0, 0);
        TimeSpan end = new TimeSpan(18, 0, 0);
        return input >= start && input < end;
    }

    public static string Description(DateTime appointmentDate)
    {
        string date = appointmentDate.ToString();
        return $"You have an appointment on {date}.";
    }

    public static DateTime AnniversaryDate()
    {
        int year = DateTime.Now.Year;
        return new DateTime(year, 9, 15, 0, 0, 0);
    }
}
