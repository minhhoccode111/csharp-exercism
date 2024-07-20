// add 'public' to be accessible in test file
public class Lasagna
{
    // this will create a private property _time on each instance
    private int _time;

    /*
    this will create a private property _time on the Lasagna class 
    private static int _time;
    */

    // add 'public' to be accessible in test file
    public Lasagna()
    {
        _time = 40;
    }

    public int ExpectedMinutesInOven()
    {
        return _time;
    }

    public int RemainingMinutesInOven(int min)
    {
        return _time - min;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int min)
    {
        return layers * 2 + min;
    }
}
