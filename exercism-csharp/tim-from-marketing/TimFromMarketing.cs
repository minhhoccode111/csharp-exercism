using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idStr = id != null ? $"[{id}] - " : "";
        string departmentStr = department?.ToUpper() ?? "OWNER";

        return $"{idStr}{name} - {departmentStr}";
    }
}
