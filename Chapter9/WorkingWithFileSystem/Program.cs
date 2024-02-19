using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using static System.Console;

static void OutputFileSystemInfo()
{
    WriteLine($"{"Path.PathSeparator",-33} {PathSeparator}");
    WriteLine($"{"Path.DirectorySeparatorChar",-33} {DirectorySeparatorChar}");
    WriteLine($"{"Directory.GetCurrentDirectory()",-33} {GetCurrentDirectory()}");
    WriteLine($"{"Environment.CurrentDirectory",-33} {CurrentDirectory}");
    WriteLine($"{"Environment.SystemDirectory",-33} {SystemDirectory}");
    WriteLine($"{"Path.GetTempPath()",-33} {GetTempPath()}");

    WriteLine("GetFolderPath(SpecialFolder");
    WriteLine($"{".System",-33} {GetFolderPath(SpecialFolder.System)}");
    WriteLine($"{".ApplicationData",-33} {GetFolderPath(SpecialFolder.ApplicationData)}");
    WriteLine($"{".MyDocuments",-33} {GetFolderPath(SpecialFolder.MyDocuments)}");
    WriteLine($"{".Personal",-33} {GetFolderPath(SpecialFolder.Personal)}");
}


static void WorkingWithDrives()
{
    WriteLine($"{"NAME",-30} |{"TYPE",-10} | {"FORMAT",-7} | {"SIZE(BYTES)",18} | {"FREE SPACE",18}");
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine($"{drive.Name,-30} |{drive.DriveType,-10} | {drive.DriveFormat,-7} | {drive.TotalSize,18} | {drive.TotalFreeSpace,18}");
        }
        else
        {
            WriteLine($"{drive.Name,-30}");
        }
    }
}

static void WorkingWithDirectories()
{
    string newFolder = Combine(CurrentDirectory, "New Folder");

    WriteLine($"Working with {newFolder}");
    WriteLine($"Does it exists? {Directory.Exists(newFolder)}");
    WriteLine("Create it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exists? {Directory.Exists(newFolder)}");
    Write("Confirm the directory exists, and then press ENTER: ");
    ReadLine();

    WriteLine("Deleting this...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exists? {Directory.Exists(newFolder)}");
}

static void WorkWithFiles()
{
    string dir = Combine(CurrentDirectory, "Output Files");
    CreateDirectory(dir);

    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with {textFile}");

    WriteLine($"Does it exists? {File.Exists(textFile)}");

    StreamWriter textWritter = File.CreateText(textFile);
    textWritter.WriteLine("Hello, C#");
    textWritter.Close();

    WriteLine($"Does it exists? {File.Exists(textFile)}");

    File.Copy(textFile, backupFile, true);
    WriteLine($"Does {backupFile} exists? {File.Exists(backupFile)}");
    Write("Confirm the files and press ENTER: ");
    ReadLine();

    File.Delete(textFile);
    WriteLine($"Does it exists? {File.Exists(textFile)}");

    WriteLine("READING CONTENTS OF BACKUP");
    StreamReader textReader = File.OpenText(backupFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();
    WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
    WriteLine($"File Name: {GetFileName(textFile)}");
    WriteLine("File Name without Extension: {0}",
     GetFileNameWithoutExtension(textFile));
    WriteLine($"File Extension: {GetExtension(textFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");

}

// OutputFileSystemInfo();
// WorkingWithDrives();
// WorkingWithDirectories();
WorkWithFiles();