using System;

static class SavingsAccount
{
    /*
    floating-point in C#
    float  : 4 bytes  (~6 - 9 digits precision)  : 2.45f
    double : 8 bytes  (~15 - 17 digits precision): 2.45 or 2.45d
    decimal: 16 bytes (~28 - 29 digits precision): 2.45m
    */

    public static float InterestRate(decimal balance)
    {
        switch (balance)
        {
            case < 0:
                return 3.213f;
            case < 1000:
                return 0.5f;
            case < 5000:
                return 1.621f;
            default:
                return 2.475f;
        }
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        decimal currBalance = balance;
        int year = 0;

        while (currBalance < targetBalance)
        {
            currBalance = AnnualBalanceUpdate(currBalance);
            year++;
        }

        return year;
    }
}
