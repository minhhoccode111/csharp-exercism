using System;

public static class TelemetryBuffer
{
    private static byte getPrefix(long number)
    {
        if (number > long.MaxValue)
            return 8;
        if (number > uint.MaxValue)
            return 256 - 8;
        if (number > int.MaxValue)
            return 4;
        if (number > ushort.MaxValue)
            return 256 - 4;
        if (number > -1)
            return 2;
        if (number >= short.MinValue)
            return 256 - 2;
        if (number >= int.MinValue)
            return 256 - 4;
        return 256 - 8;
    }

    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];
        result[0] = getPrefix(reading);
        byte[] bytes = new byte[8];
        // have to decide which number type to create proper Buffer
        byte numberToCopy;
        if (result[0] == 2 || result[0] == 254)
        {
            bytes = BitConverter.GetBytes((short)reading);
            numberToCopy = 2;
        }
        else if (result[0] == 4 || result[0] == 252)
        {
            bytes = BitConverter.GetBytes((int)reading);
            numberToCopy = 4;
        }
        else
        {
            bytes = BitConverter.GetBytes((long)reading);
            numberToCopy = 8;
        }
        // bytes: source, 0: source start index, result: destination, 1: destination index, bytes.Length: number of items to copy
        Array.Copy(bytes, 0, result, 1, numberToCopy);
        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];
        byte[] bytes = new byte[8];
        Array.Copy(buffer, 1, bytes, 0, 8);
        long result;

        if (prefix == 2)
        {
            result = BitConverter.ToUInt16(bytes);
            return result;
        }
        else if (prefix == 256 - 2)
        {
            result = BitConverter.ToInt16(bytes);
            return result;
        }
        else if (prefix == 4)
        {
            result = BitConverter.ToUInt32(bytes);
            return result;
        }
        else if (prefix == 256 - 4)
        {
            result = BitConverter.ToInt32(bytes);
            return result;
        }
        else if (prefix == 256 - 8)
        {
            result = BitConverter.ToInt64(bytes);
            return result;
        }

        return 0L;
    }
}
