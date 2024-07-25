using System;
using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        List<string> list = new List<string>();
        list.Add("C#");
        list.Add("Clojure");
        list.Add("Elm");
        return list;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse(0, languages.Count);
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.IndexOf("C#") == 0)
        {
            return true;
        }
        else if (languages.IndexOf("C#") == 1 && (languages.Count == 2 || languages.Count == 3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        int index = languages.IndexOf(language);
        if (index > -1)
        {
            languages.RemoveAt(index);
        }
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        for (int i = 0, len = languages.Count; i < len; i++)
        {
            string curr = languages[i];
            int index = languages.IndexOf(curr);
            if (index != i)
            {
                return false;
            }
        }
        return true;
    }
}
