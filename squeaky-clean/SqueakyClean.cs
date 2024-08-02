using System;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        identifier = identifier.Replace(" ", "_").Replace("\0", "CTRL");
        string result = "";
        bool flag = false;
        for (int i = 0; i < identifier.Length; i++)
        {
            char curr = identifier[i];
            if (
                (curr >= 945 && curr <= 969) || (!char.IsLetter(curr) && curr != '_' && curr != '-')
            )
            {
                //
            }
            else if (curr == '-')
            {
                flag = true;
            }
            else if (flag)
            {
                result += char.ToUpper(curr);
                flag = false;
            }
            else
            {
                result += curr;
            }
        }

        return result;
    }
}
