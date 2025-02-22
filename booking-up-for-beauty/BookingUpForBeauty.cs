using System;

static class Appointment
{
    public static DateTime Schedule(string s) =>
        DateTime.TryParse(s, out DateTime result) ? result : throw new ArgumentException();

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now > appointmentDate;

    public static bool IsAfternoonAppointment(DateTime dt) => dt.Hour >= 12 && dt.Hour < 18;

    public static string Description(DateTime dt) =>
        $"You have an appointment on {dt.ToString("M/d/yyyy h:mm:ss tt")}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15);
}
