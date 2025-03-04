using System.Text;

internal class Program
{
    // DriveInfo - working with system drive
    // DirectoryInfo / Directory - working with directory
    // FileInfo / File - working with file

    private static void Main(string[] args)
    {
        #region Drives
        // var - auto-detect type
        var drives = DriveInfo.GetDrives();

        foreach (var d in drives)
        {
            if (d.IsReady)
                Console.WriteLine($"Drive {d.VolumeLabel}: {d.Name} {d.DriveFormat}, size: {d.TotalFreeSpace / 1024.0 / 1024 / 1024}");
            else
                Console.WriteLine($"Drive {d.Name} is not ready for use!");
        }
        #endregion

        #region Directories
        // ------------------ working with directories

        // Path - working with file system paths
        // GetExnetsion(), Combine(), GetFileName()

        // get system directories
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string dirName = "test_folder";

        // @ - avoid escape sequences
        if (!Directory.Exists($@"{desktopPath}/{dirName}"))
        {
            Directory.CreateDirectory(Path.Combine(desktopPath, dirName)); // add separator
                                                                           // depends on OS
        }

        DirectoryInfo dir = new DirectoryInfo(Path.Combine(desktopPath, dirName));

        Console.WriteLine($"New Directory Info: {dir.Name} created at {dir.CreationTime}\n" +
            $"Last access: {dir.LastAccessTime} | Last write time: {dir.LastWriteTime}\n");

        // --------- get directories and files
        var desktop = new DirectoryInfo(desktopPath);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--------------- Desktop Directories ---------------");
        foreach (var d in desktop.GetDirectories())
        {
            Console.WriteLine(d.Name);
        }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--------------- Desktop Files ---------------");
        foreach (var d in desktop.GetFiles())
        {
            Console.WriteLine("\t" + d.Name);
        }
        Console.ResetColor();

        // --------- search files
        /* pattern symbols:
            [*] - any characters sequence
            [?] - any signle character
        */
        foreach (var f in dir.GetFiles("f*.tx?", SearchOption.AllDirectories))
        {
            Console.WriteLine($"File: {f.Name} | {f.Length / 1024}KB");
        }

        //dir.MoveTo("...");

        //dir.Delete();       // delete if directory is empty
        //dir.Delete(true);   // delete directory with all content
        #endregion

        #region Files
        // ------------------ working with files

        string fileName = "my_file.txt";
        string filePath = Path.Combine(desktopPath, fileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        // write content
        File.WriteAllText(filePath, "Hello from C#!!!\n");
        File.AppendAllText(filePath, "We are here again...");

        // read content
        string content = File.ReadAllText(filePath);
        Console.WriteLine($"Content: {string.Join("", content.Take(10))}...");

        var file = new FileInfo(filePath);

        //file.MoveTo("...");
        file.CopyTo(Path.Combine(dir.FullName, fileName), true); // overrite existing file
        //file.Delete();
        #endregion

        // ------------------ working with File Streams
        FileStream fs = new FileStream(filePath, FileMode.Open);

        // fs.Write() - write bytes to the file
        // fs.Read()  - read bytes from the file

        string text = "Blabla text data!";

        fs.Write(Encoding.UTF8.GetBytes(text));
        fs.Close(); // close file

        // --------- text streams: StreamReader, StreamWriter

        //StreamWriter writer = new(fs);
        //StreamWriter writer = new(filePath);

        using (StreamWriter writer = File.CreateText(filePath))
        {
            writer.WriteLine(text);
            writer.Write("Additional line. Last word in the file.");

        } // auto clear resources here: try {...} finally { Dispose() }

        using (StreamReader reader = File.OpenText(filePath))
        {
            string all = reader.ReadToEnd();
            Console.WriteLine($"All text: {all}"); 
        }
    }
}