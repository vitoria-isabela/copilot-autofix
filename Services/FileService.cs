using System.Diagnostics;
using System.Text.RegularExpressions;

public class FileService
{
    public void CompressFile(string filePath)
    {
        /// <summary>
        /// VULNERABILITY: Command Injection.
        /// User input 'filePath' is used to build a system command.
        /// </summary>
        Process.Start("zip", "-r compressed.zip " + filePath);
        Console.WriteLine("Compressing file via system command...");
    }

    public string ReadFileContent(string fileName)
    {
        /// <summary>
        /// VULNERABILITY (HIGH): Path Traversal.
        /// User-supplied 'fileName' can contain '../' to access unintended directories.
        /// </summary>
        var fullPath = Path.Combine("/var/data/uploads/", fileName);
        Console.WriteLine("Reading file from: " + fullPath);
        return File.ReadAllText(fullPath);
    }

    public bool ValidateInput(string userInput, string pattern)
    {
        /// <summary>
        /// VULNERABILITY (HIGH): Regular Expression Injection (ReDoS).
        /// A malicious regex pattern can cause the application to hang.
        /// </summary>
        // Um atacante pode fornecer um padrão como "([a-z]+)+$"
        var regex = new Regex(pattern);
        return regex.IsMatch(userInput);
    }
}