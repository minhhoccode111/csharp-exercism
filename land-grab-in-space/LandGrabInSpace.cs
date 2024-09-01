using System;
using System.Collections.Generic;

public struct Coord : IComparable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override bool Equals(Object obj)
    {
        if (obj is Coord convertedObj)
        {
            return convertedObj.GetHashCode() == this.GetHashCode();
        }
        return false;
    }

    public int CompareTo(Coord other)
    {
        if (X > other.X || Y > other.Y)
            return -1;
        if (X < other.X || Y < other.Y)
            return 1;
        return 0;
    }
}

public struct Plot : IComparable<Plot>
{
    public readonly Coord C1;
    public readonly Coord C2;
    public readonly Coord C3;
    public readonly Coord C4;

    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        this.C1 = c1;
        this.C2 = c2;
        this.C3 = c3;
        this.C4 = c4;
    }

    public override int GetHashCode()
    {
        return C1.GetHashCode() ^ C2.GetHashCode() ^ C3.GetHashCode() ^ C4.GetHashCode();
    }

    public override bool Equals(Object obj)
    {
        if (obj is Plot convertedObj)
        {
            return convertedObj.C1.Equals(C1)
                && convertedObj.C2.Equals(C2)
                && convertedObj.C3.Equals(C3)
                && convertedObj.C4.Equals(C4);
        }
        return false;
    }

    private int getAllYs()
    {
        return C1.Y + C2.Y + C3.Y + C4.Y;
    }

    private int getAllXs()
    {
        return C1.X + C2.X + C3.X + C4.X;
    }

    public int CompareTo(Plot other)
    {
        if (getAllXs() + getAllYs() > other.getAllYs() + other.getAllXs())
            return -1;
        if (getAllXs() + getAllYs() < other.getAllYs() + other.getAllXs())
            return 1;
        return 0;
    }
}

public class ClaimsHandler
{
    private List<Plot> _plot = new List<Plot>();

    public void StakeClaim(Plot plot)
    {
        _plot.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _plot[_plot.Count - 1].Equals(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return _plot[_plot.Count - 1].Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        _plot.Sort();
        return _plot[0];
    }
}
