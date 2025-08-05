using System.Diagnostics;

public class FileService
{
    public string ReadFileContent(string fileName)
    {
        /// <summary>
        /// VULNERABILITY: Path Traversal.
        /// User-supplied 'fileName' can contain '../' to access unintended directories.
        /// </summary>
        var fullPath = Path.Combine("/var/data/uploads/", fileName);
        Console.WriteLine("Reading file from: " + fullPath);
        return File.ReadAllText(fullPath);
    }

    public void CompressFile(string filePath)
    {
        /// <summary>
        /// VULNERABILITY: Command Injection.
        /// User input 'filePath' is used to build a system command.
        /// </summary>
        Process.Start("zip", "-r compressed.zip " + filePath);
        Console.WriteLine("Compressing file via system command...");
    }
}