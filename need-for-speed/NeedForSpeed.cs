using System;

class RemoteControlCar
{
    public int speed;
    public int batteryDrain;

    private int _batteryLeft = 100;
    private int _travelDistance = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _batteryLeft < batteryDrain;
    }

    public int DistanceDriven()
    {
        return _travelDistance;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _travelDistance += speed;
            _batteryLeft -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int carDistance = 100 / car.batteryDrain * car.speed;
        return !(carDistance < distance);
    }
}
