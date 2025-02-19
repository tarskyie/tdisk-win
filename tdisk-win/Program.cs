using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            args = new string[] { "-ts", "-rs", "-pfs", "-fs", "-dt" };
        }

        var argsSet = new HashSet<string>(args);

        Console.WriteLine("TDISK-Win / tarskyie");

        // Iterate through all disks
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                DriveProcessing(drive, argsSet);
            }
            else
            {
                Console.WriteLine("Drive: {0} is not ready.", drive.Name);
            }
        }
    }

    static void DriveProcessing(DriveInfo drive, HashSet<string> args)
    {
        // Values
        double freeSpace = drive.TotalFreeSpace;
        double totalSpace = drive.TotalSize;
        double percentFree = totalSpace > 0 ? (freeSpace / totalSpace) * 100 : 0;
        // Strings
        string ts = $"Total Space: {drive.TotalSize / (1024 * 1024 * 1024)} GB";
        string rs = $"Space Remaining: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB";
        string pfs = $"Percent Free Space: {Math.Round(percentFree, 2)}%";
        string fs = $"File System: {drive.DriveFormat}";
        string dt = $"Type: {drive.DriveType}";

        Console.WriteLine("\nDrive: {0}", drive.Name);

        if (args.Contains("-ts"))
        {
            Console.WriteLine(ts);
        }
        if (args.Contains("-rs"))
        {
            Console.WriteLine(rs);
        }
        if (args.Contains("-pfs"))
        {
            Console.WriteLine(pfs);
        }
        if (args.Contains("-fs"))
        {
            Console.WriteLine(fs);
        }
        if (args.Contains("-dt"))
        {
            Console.WriteLine(dt);
        }
    }
}
