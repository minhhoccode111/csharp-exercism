using System;

class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }

    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    public string DisplayWeight
    {
        // get { return Math.Round(_weight - TareAdjustment, Precision); }
        get
        {
            double weight = Math.Round(_weight - TareAdjustment, Precision);
            string format = weight.ToString($"F{Precision}");
            return $"{format} kg";
        }
    }

    public double TareAdjustment { get; set; } = 5.0;
}
