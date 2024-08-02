using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case string:
                return report.ToString()!;
            case int:
                return $"There are {report} supporters at the match.";
            case Injury obj:
                return $"Oh no! {obj.GetDescription()} Medics are on the field.";
            case Incident obj:
                return obj.GetDescription();
            case Manager obj:
                return obj.Club == null ? obj.Name : $"{obj.Name} ({obj.Club})";
            default:
                throw new ArgumentException();
        }
    }
}
