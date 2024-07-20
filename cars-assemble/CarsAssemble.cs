using System;

static class AssemblyLine
{
    private static ushort _cars = 221;

    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0;
        }
        if (speed < 5)
        {
            return 1;
        }
        if (speed < 9)
        {
            return 0.9;
        }
        if (speed == 9)
        {
            return 0.8;
        }
        return 0.77;
    }

    public static double ProductionRatePerHour(int speed)
    {
        double rate = SuccessRate(speed);
        int produceCars = _cars * speed;

        return produceCars * rate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double successProduce = ProductionRatePerHour(speed);
        return (int)successProduce / 60;
    }
}
