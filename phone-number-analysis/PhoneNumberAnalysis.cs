using System;

public static class PhoneNumber
{
    private static string _ny = "212";
    private static string _fake = "555";

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] splited = phoneNumber.Split('-');
        string one = splited[0];
        string two = splited[1];
        string three = splited[2];
        return (_ny == one, _fake == two, three);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
