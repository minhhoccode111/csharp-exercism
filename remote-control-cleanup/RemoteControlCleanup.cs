public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public CTelemetry Telemetry { get; set; }

    public class CTelemetry
    {
        private RemoteControlCar _car;

        public CTelemetry(RemoteControlCar car)
        {
            _car = car;
        }

        public void Calibrate()
        {
            //
        }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => _car.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            _car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public RemoteControlCar() => Telemetry = new CTelemetry(this);

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => currentSpeed = speed;
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond,
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return $"{Amount} {unitsString}";
    }
}
