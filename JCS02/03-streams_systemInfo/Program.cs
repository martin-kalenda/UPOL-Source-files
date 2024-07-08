using cs203;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

// return memory unit suffix, optional convert parameter is used to show the values in bytes without converting them to the largest possible unit
string appendUnits(double bytes, bool convert = true)
{
    string[] units = new string[] { "B", "KB", "MB", "GB", "TB" };
    int unitIndex = 0;

    string res = string.Format("{0} {1}", bytes, units[0]);

    if (convert)
    {
        while (bytes >= 1024)
        {
            bytes /= 1024;
            unitIndex++;
        }
        res = string.Format("{0:0.00} {1}", bytes, units[unitIndex]);
    }
    return res;
}


//************************
//*                      *
//*          01          *
//*                      *
//************************

// print all drives and their total and free space, optional convert parameter is used to show the values in bytes without converting them to the largest possible unit
void printDiskInfo(bool convert = true)
{
    DriveInfo[] drives = DriveInfo.GetDrives();

    if (drives.Length == 0)
    {
        Console.WriteLine("No drives found.");
        return;
    }

    int drivePad = Math.Max(drives.Max(d => d.Name.Length), "Drives".Length);
    int typePad = Math.Max(drives.Max(d => d.DriveType.ToString().Length), "Type".Length);
    int sizePad = Math.Max(drives.Max(d => appendUnits(d.TotalSize, convert).Length), "Total Space".Length);
    int freePad = Math.Max(drives.Max(d => appendUnits(d.TotalFreeSpace, convert).Length), "Free Space".Length);

    Console.WriteLine($"{"drive:".PadRight(drivePad)}\t{"type:".PadRight(typePad)}\t{"size:".PadRight(sizePad)}\t{"free:".PadRight(freePad)}");
    foreach (DriveInfo disk in DriveInfo.GetDrives())
    {
        Console.WriteLine($"{disk.ToString().PadRight(drivePad)}\t{disk.DriveType.ToString().PadRight(typePad)}\t{appendUnits(disk.TotalSize, convert).PadRight(sizePad)}\t{appendUnits(disk.TotalFreeSpace, convert).PadRight(freePad)}");
    }
}


//************************
//*                      *
//*          02          *
//*                      *
//************************

// print all files and subdirectories of a given directory
void printDirectory(string? path, bool convert = true)
{
    try
    {
        if (path == null)
        {
            throw new ArgumentNullException("path", "Path is null.");
        }
        if (path == "")
        {
            throw new ArgumentException("Path is empty.", "path");
        }

        DirectoryInfo directory = new DirectoryInfo(path);

        if (!directory.Exists)
        {
            throw new DirectoryNotFoundException($"Directory \'{path}\' not found.");
        }

        FileInfo[] files = directory.GetFiles();
        DirectoryInfo[] subdirectories = directory.GetDirectories();

        int createdPad = Math.Max(files.Max(f => f.CreationTime.ToString("dd.mm.yyyy").Length), subdirectories.Max(sd => sd.CreationTime.ToString("dd.mm.yyyy").Length));
        int sizePad = Math.Max(files.Max(f => appendUnits(f.Length, convert).Length), "<DIR>".Length);
        int namePad = Math.Max(files.Max(f => f.Name.Length), subdirectories.Max(sd => sd.Name.Length));

        Console.WriteLine($"Files and subdirectories of \'{path}\':");
        foreach (DirectoryInfo subdirectory in directory.GetDirectories())
        {
            Console.WriteLine($"{subdirectory.CreationTime.ToString("dd.mm.yyyy").PadRight(createdPad)}\t{"<DIR>".PadRight(sizePad)}\t{subdirectory.Name.PadRight(namePad)}");
        }
        foreach (FileInfo file in directory.GetFiles())
        {
            Console.WriteLine($"{file.CreationTime.ToString("dd.mm.yyyy").PadRight(createdPad)}\t{appendUnits(file.Length, convert).PadRight(sizePad)}\t{file.Name.PadRight(namePad)}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An exception occured: {ex.Message}");
    }
}
// driver code

// set this to test WriteMatrix and ReadMatrix
string path = "";

printDiskInfo();

Console.Write("\nEnter directory path: ");
printDirectory(Console.ReadLine());

Console.WriteLine();

BinaryMatrix bmw = new BinaryMatrix(new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 1, 1, 1 } });
Console.WriteLine($"matrix1\n{bmw}");

Console.WriteLine($"matrix1 after Set(2, 1, false)");
bmw.Set(2, 1, false);
Console.WriteLine(bmw);

Console.WriteLine($"writing matrix1 to {path}");
bmw.WriteMatrix(path, true);

Console.WriteLine($"\nreading matrix2 from {path}");
BinaryMatrix? bmr = BinaryMatrix.ReadMatrix(path);

Console.WriteLine($"\nmatrix2\n{bmr}");