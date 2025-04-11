public class Lasagna
{
    private int _time;

    public Lasagna() => _time = 40;

    public int ExpectedMinutesInOven() => _time;

    public int RemainingMinutesInOven(int min) => _time - min;

    public int PreparationTimeInMinutes(int layers) => layers * 2;

    public int ElapsedTimeInMinutes(int layers, int min) => layers * 2 + min;
}
