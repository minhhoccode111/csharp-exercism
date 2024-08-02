using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string>
        {
            [1] = "United States of America",
            [55] = "Brazil",
            [91] = "India",
        };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(
        int countryCode,
        string countryName
    )
    {
        Dictionary<int, string> result = GetEmptyDictionary();
        result.Add(countryCode, countryName);
        return result;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode,
        string countryName
    )
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode
    )
    {
        bool isContain = existingDictionary.ContainsKey(countryCode);
        if (isContain)
        {
            return existingDictionary[countryCode];
        }
        return "";
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode,
        string countryName
    )
    {
        bool isContain = existingDictionary.ContainsKey(countryCode);
        if (isContain)
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode
    )
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string result = "";
        foreach (var item in existingDictionary.Values)
        {
            if (item.Length > result.Length)
            {
                result = item;
            }
        }
        return result;
    }
}

