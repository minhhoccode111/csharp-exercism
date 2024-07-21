// using System;

class RemoteControlCar
{
    // init on each instance
    private int _batteriesPercent = 100;
    private int _drivenDistance = 0;

    private const int _onePercentDistance = 20;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_drivenDistance} meters";
    }

    public string BatteryDisplay()
    {
        if (_batteriesPercent < 1)
        {
            return "Battery empty";
        }
        return $"Battery at {_batteriesPercent}%";
    }

    public void Drive()
    {
        if (_batteriesPercent < 1)
        {
            return;
        }
        _drivenDistance += _onePercentDistance;
        _batteriesPercent--;
    }
}
