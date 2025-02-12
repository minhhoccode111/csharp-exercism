class RemoteControlCar
{
    private int _speed { get; set; }
    private int _batteryDrain { get; set; }
    private int _distance { get; set; } = 0;
    private int _battery { get; set; } = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        _battery -= _batteryDrain;
        if (_battery < 0)
        {
            return;
        }
        _distance += _speed;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _distance { get; set; }

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }
        return car.DistanceDriven() >= _distance;
    }
}
