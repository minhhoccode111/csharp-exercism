using System;

// TODO: erase everything and do this problem again
public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9]; // this is smart
        byte prefixByte;
        byte[] valueBytes;

        if (reading >= 4_294_967_296 && reading <= 9_223_372_036_854_775_807)
        {
            // 0x00 - 8 bytes
            prefixByte = 0xf8; // 8 bytes, signed
            valueBytes = BitConverter.GetBytes((long)reading);
        }
        else if (reading >= 2_147_483_648 && reading <= 4_294_967_295)
        {
            // 0x00 + 4 bytes
            prefixByte = 4; // 4 bytes, unsigned
            valueBytes = BitConverter.GetBytes((uint)reading);
        }
        else if (
            (reading >= 65_536 && reading <= 2_147_483_647)
            || (reading >= -2_147_483_648 && reading <= -32_769)
        )
        {
            // 0x00 - 4 bytes
            prefixByte = 0xfc; // 4 bytes, signed
            valueBytes = BitConverter.GetBytes((int)reading);
        }
        else if (reading >= 0 && reading <= 65_535)
        {
            // 0x00 + 2 bytes
            prefixByte = 2; // 2 bytes, unsigned
            valueBytes = BitConverter.GetBytes((ushort)reading);
        }
        else if (reading >= -32_768 && reading <= -1)
        {
            // 0x00 - 2 bytes
            prefixByte = 0xfe; // 2 bytes, signed
            valueBytes = BitConverter.GetBytes((short)reading);
        }
        else // long
        {
            // 0x00 - 8 bytes
            prefixByte = 0xf8; // 8 bytes, signed
            valueBytes = BitConverter.GetBytes(reading);
        }

        buffer[0] = prefixByte;
        Array.Copy(valueBytes, 0, buffer, 1, valueBytes.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer.Length < 9)
            return 0;

        byte prefixByte = buffer[0];
        int byteCount = prefixByte <= 8 ? prefixByte : 256 - prefixByte;

        if (byteCount != 2 && byteCount != 4 && byteCount != 8)
            return 0;

        switch (prefixByte)
        {
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 0xfe:
                return BitConverter.ToInt16(buffer, 1);
            case 0xfc:
                return BitConverter.ToInt32(buffer, 1);
            case 0xf8:
                return BitConverter.ToInt64(buffer, 1);
            default:
                return 0;
        }
    }
}
