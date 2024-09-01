using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(Object obj)
    {
        if (obj is FacialFeatures convertedObj)
            return this.GetHashCode() == convertedObj.GetHashCode();

        return false;
    }

    public override int GetHashCode() => EyeColor.GetHashCode() ^ PhiltrumWidth.GetHashCode();
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(Object obj)
    {
        if (obj is Identity convertedObj)
            return convertedObj.GetHashCode() == this.GetHashCode();

        return false;
    }

    public override int GetHashCode() => Email.GetHashCode() ^ FacialFeatures.GetHashCode();
}

public class Authenticator
{
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity)
    {
        FacialFeatures adminFacial = new FacialFeatures("green", 0.9m);
        Identity admin = new Identity("admin@exerc.ism", adminFacial);
        return admin.Equals(identity);
    }

    private HashSet<Identity> sets = new HashSet<Identity>();

    public bool Register(Identity identity) => sets.Add(identity);

    public bool IsRegistered(Identity identity) => sets.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        identityA == identityB;
}
