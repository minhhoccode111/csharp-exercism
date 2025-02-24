class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get; }

    // TODO: define the 'Weight' property
    private double weight;
    public double Weight
    {
        get => weight;
        set => weight = value >= 0 ? value : throw new ArgumentOutOfRangeException();
    }

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight => (Weight - TareAdjustment).ToString($"F{Precision}") + " kg";

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5;

    public WeighingMachine(int precision) => Precision = precision;
}
