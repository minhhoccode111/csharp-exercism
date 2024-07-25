public class Inheritance
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}

// inherits from the 'object' class
abstract class Vehicle
{
    protected Vehicle(int wheels)
    {
        Console.WriteLine("Called first");
    }

    // can be overridden
    public virtual void Drive()
    {
        //
    }

    // must be overridden
    protected abstract int Speed();

    public abstract string GetDescription();
}

// inherit
class Car : Vehicle
{
    public Car()
        : base(4)
    {
        Console.WriteLine("Called second");
    }

    public override void Drive()
    {
        // override virtual method

        // call parent implementation
        base.Drive();
    }

    protected override int Speed()
    {
        // implement abstract method

        throw new NotImplementedException();
    }

    public override string GetDescription()
    {
        return "Runabout";
    }
}

// inherit, polymorphism
class Rig : Vehicle
{
    public Rig()
        : base(4) { }

    public override string GetDescription()
    {
        return "Big Rig";
    }

    protected override int Speed()
    {
        // implement abstract method

        throw new NotImplementedException();
    }
}
