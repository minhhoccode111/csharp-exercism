using System;

class RemoteControlCar
{
    private int distance = 0;
    private int battery = 100;
    private int distancePerBattery = 20;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => battery > 0 ? $"Battery at {battery}%" : "Battery empty";

    public void Drive()
    {
        if (battery == 0)
        {
            return;
        }
        distance += distancePerBattery;
        battery--;
    }
}
