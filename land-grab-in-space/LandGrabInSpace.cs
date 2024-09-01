using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public struct Coord
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
}

public struct Plot
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
            return convertedObj.GetHashCode() == this.GetHashCode();
        }
        return false;
    }
}

public class ClaimsHandler
{
    private Plot _plot;

    public void StakeClaim(Plot plot)
    {
        _plot = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _plot.Equals(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        throw new NotImplementedException(
            "Please implement the ClaimsHandler.IsLastClaim() method"
        );
    }

    public Plot GetClaimWithLongestSide()
    {
        throw new NotImplementedException(
            "Please implement the ClaimsHandler.GetClaimWithLongestSide() method"
        );
    }
}
