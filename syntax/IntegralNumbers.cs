public class IntegralNumbers
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");

        // sbyte: 1 byte number
        sbyte num0 = 127; // from -128 to 127
        // sbyte num1 = 128; // error

        // check with
        Console.WriteLine(sbyte.MinValue); // -128
        Console.WriteLine(sbyte.MaxValue); // 127
        /*
           so:
           sbyte/byte: 1 byte
           short/ushort: 2 byte
           int/uint: 4 byte
           long/ulong: 8 byte
        */
    }
}
