using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) =>
        studentA.PadLeft(29, ' ') + " ♡ " + studentB.PadRight(29, ' ');

    public static string DisplayBanner(string studentA, string studentB) =>
        $"""
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{studentA.PadLeft(11, ' ') + " +  " + studentB.PadRight(10, ' ')}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
""";

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours
    )
    {
        var culture = new CultureInfo("de-DE");
        return $"{studentA} and {studentB} have been dating since {start.ToString("d", culture)} - that's {hours.ToString("N2", culture)} hours";
    }
}
