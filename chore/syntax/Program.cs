// See https://aka.ms/new-console-template for more information

using System;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World! From Syntax");

            // INHERITANCE
            // new Car().GetDescription(); // Runabout
            // new Rig().GetDescription(); // Big Rig

            // INTEGRAL NUMBERS

            // IntegralNumbers();

            // DICTIONARY
            Dictionaries();
        }

        // ######################### INTEGRAL NUMBERS ###############################
        private static void IntegralNumbers()
        {
            // > than 9223372036854775807 will be an ulong 8
            Console.WriteLine(long.MaxValue); // 9223372036854775807

            // > than 4294967295 will be a long -8
            Console.WriteLine(uint.MaxValue); // 4294967295

            // > than 2147483647 will be an uint 4
            Console.WriteLine(int.MaxValue); // 2147483647

            // > than 65535 will be an int -4
            Console.WriteLine(ushort.MaxValue); // 65535

            // > than -1 will be a ushort 2
            Console.WriteLine(-1); // -1

            // use >= because low bound has 1 more extra
            // Console.WriteLine(sbyte.MaxValue); // 127
            // Console.WriteLine(sbyte.MinValue); // -128

            // >= than -32768 will be a short -2
            Console.WriteLine(short.MinValue); // -32768

            // >= than -2_147_483_648 will be an int -4
            Console.WriteLine(int.MinValue); // -2147483648

            // >= than -9_223_372_036_854_775_808 will be a long -8
            Console.WriteLine(long.MinValue); // -9_223_372_036_854_775_808
        }

        private static void Dictionaries()
        {
            Dictionary<int, string> a = new Dictionary<int, string>();

            Dictionary<int, string> b = new Dictionary<int, string> { [1] = "One", [2] = "Two" };

            Dictionary<int, string> c = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } };

            // Console.WriteLine(a[1]);
            Console.WriteLine(b[1]);
            Console.WriteLine(b[2]);
            Console.WriteLine(c[1]);
            Console.WriteLine(c[2]);
            c[2] = "Khong dieu kien";
            Console.WriteLine(c[2]);

            Dictionary<string, string> d = new Dictionary<string, string>
            {
                ["Khong"] = "Khong",
                ["Tai"] = "Tai",
                ["Vi"] = "Vi",
                ["Sao"] = "Sao",
            };

            Console.WriteLine(d.ContainsKey("Khong")); // true
            Console.WriteLine(d.ContainsKey("Dieu")); // true
        }
    }

    // ######################### INHERITANCE ###################################
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
}
