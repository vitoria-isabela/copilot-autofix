public class Program
{
    public static void Main(string[] args)
    {
        string userInput = "../../../etc/passwd";

        string filePath = Path.Combine("/var/www/uploads/", userInput);

        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("File content: " + fileContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}