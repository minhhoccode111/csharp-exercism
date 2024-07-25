using System;

abstract class Character
{
    private string _info;

    protected Character(string characterType)
    {
        _info = $"Character is a {characterType}";
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return _info;
    }
}

class Warrior : Character
{
    public Warrior()
        : base("Warrior") { }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        else
        {
            return 6;
        }
    }
}

class Wizard : Character
{
    private bool _isPreparedSpell = false;

    public Wizard()
        : base("Wizard") { }

    public override int DamagePoints(Character target)
    {
        return _isPreparedSpell ? 12 : 3;
    }

    public override bool Vulnerable()
    {
        return !_isPreparedSpell;
    }

    public void PrepareSpell()
    {
        _isPreparedSpell = true;
    }
}
