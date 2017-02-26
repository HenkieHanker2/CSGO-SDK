using System;
using System.Runtime.InteropServices;
using csgo.sdk;
class Memory
{
    // Read Process Memory
    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);
    // Write Process Memory
    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
    public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesWrite);

    public static int ReadInt(int adr, int len = 4)
    {
        // Set new Byte and length
        byte[] bufr = new byte[len];
        // Read from Memory
        ReadProcessMemory(Game.TargetProcess, adr, bufr, len, 0);
        // Convert to int
        return BitConverter.ToInt32(bufr, 0);
    }

    public static float ReadFloat(int adr, int len = 4)
    {
        // Set new Byte and length
        byte[] bufr = new byte[len];
        // Read from Memory
        ReadProcessMemory(Game.TargetProcess, adr, bufr, len, 0);
        // Convert to float
        return BitConverter.ToSingle(bufr, 0);
    }

    public static void WriteInt(int adr, int val, int len = 4)
    {
        // Set new Byte and length
        byte[] bufr = new byte[len];
        // Convert to Btyes
        bufr = BitConverter.GetBytes(val);
        int lbp = 1;
        // Write to Memory
        WriteProcessMemory((IntPtr)Game.TargetProcess,(IntPtr) adr, bufr, bufr.Length,ref lbp);
    }

    public static void WriteFloat(int adr, float val, int len = 4)
    {
        // Set new Byte and length
        byte[] bufr = new byte[len];
        // Convert to Btyes
        bufr = BitConverter.GetBytes(val);
        int lbp = 1;
        // Write to Memory
        WriteProcessMemory((IntPtr)Game.TargetProcess, (IntPtr)adr, bufr, bufr.Length, ref lbp);
    }
}

