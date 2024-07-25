// See https://aka.ms/new-console-template for more information

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World! From Syntax");

            // INHERITANCE
            new Car().GetDescription(); // Runabout
            new Rig().GetDescription(); // Big Rig
        }
    }
}
