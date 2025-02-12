using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] = Today() + 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (var i in birdsPerDay)
        {
            if (i == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int result = 0;
        for (var i = 0; i < numberOfDays; i++)
        {
            result += birdsPerDay[i];
        }
        return result;
    }

    public int BusyDays()
    {
        int count = 0;
        foreach (var i in birdsPerDay)
        {
            if (i >= 5)
            {
                count++;
            }
        }
        return count;
    }
}
