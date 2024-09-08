using System;
using System.Collections.Generic;

public record FacialFeatures(string EyeColor, decimal PhiltrumWidth);

public record Identity(string Email, FacialFeatures FacialFeatures);

public class Authenticator
{
    private const string AdminEmail = "admin@exerc.ism";
    private static readonly FacialFeatures AdminFacialFeatures = new("green", 0.9m);

    private readonly Dictionary<string, Identity> _registeredIdentities = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA == faceB;

    public bool IsAdmin(Identity identity) =>
        identity.Email == AdminEmail && identity.FacialFeatures == AdminFacialFeatures;

    public bool Register(Identity identity) =>
        _registeredIdentities.TryAdd(identity.Email, identity);

    public bool IsRegistered(Identity identity) =>
        _registeredIdentities.TryGetValue(identity.Email, out var registeredIdentity)
        && registeredIdentity == identity;

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}
