using System;

public class Player
{
    public int RollDie() => new Random().Next(1, 18);

    public double GenerateSpellStrength() => (float)new Random().NextDouble();
}
