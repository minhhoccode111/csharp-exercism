using System;

static class AssemblyLine
{
    private static double BaseSpeed = 221.0;

    public static double SuccessRate(int speed)
    {
        if (speed == 10)
        {
            return 0.77;
        }
        if (speed == 9)
        {
            return 0.8;
        }
        if (speed >= 5 && speed <= 8)
        {
            return 0.9;
        }
        if (speed >= 1 && speed <= 4)
        {
            return 1;
        }
        return 0;
    }

    public static double ProductionRatePerHour(int speed) => SuccessRate(speed) * speed * BaseSpeed;

    public static int WorkingItemsPerMinute(int speed) => (int)ProductionRatePerHour(speed) / 60;
}
