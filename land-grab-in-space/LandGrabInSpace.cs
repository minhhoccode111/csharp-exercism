using System;
using System.Collections.Generic;
using System.Linq;

public readonly struct Coord : IEquatable<Coord>
{
    public ushort X { get; }
    public ushort Y { get; }

    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public bool Equals(Coord other) => X == other.X && Y == other.Y;

    public override bool Equals(object obj) => obj is Coord other && Equals(other);

    public static bool operator ==(Coord left, Coord right) => left.Equals(right);

    public static bool operator !=(Coord left, Coord right) => !(left == right);
}

public readonly struct Plot : IEquatable<Plot>
{
    public Coord C1 { get; }
    public Coord C2 { get; }
    public Coord C3 { get; }
    public Coord C4 { get; }

    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        C1 = c1;
        C2 = c2;
        C3 = c3;
        C4 = c4;
    }

    public override int GetHashCode() => HashCode.Combine(C1, C2, C3, C4);

    public bool Equals(Plot other) =>
        C1 == other.C1 && C2 == other.C2 && C3 == other.C3 && C4 == other.C4;

    public override bool Equals(object obj) => obj is Plot other && Equals(other);

    public static bool operator ==(Plot left, Plot right) => left.Equals(right);

    public static bool operator !=(Plot left, Plot right) => !(left == right);

    public int LongestSide =>
        new[]
        {
            Distance(C1, C2),
            Distance(C2, C3),
            Distance(C3, C4),
            Distance(C4, C1),
            Distance(C1, C3),
            Distance(C2, C4),
        }.Max();

    private static int Distance(Coord a, Coord b) =>
        (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
}

public class ClaimsHandler
{
    private readonly List<Plot> _plots = new List<Plot>();

    public void StakeClaim(Plot plot)
    {
        _plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => _plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => _plots.LastOrDefault() == plot;

    public Plot GetClaimWithLongestSide() =>
        _plots.OrderByDescending(p => p.LongestSide).FirstOrDefault();
}
