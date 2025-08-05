using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("--- Executing Basic Vulnerabilities ---");

        var dbService = new DatabaseService();
        dbService.GetUserData("1' OR '1'='1");
        dbService.CheckUserExists("admin'--");

        var fileService = new FileService();
        fileService.ReadFileContent("../../../boot.ini");
        fileService.ValidateInput("aaaaaaaaaaaaaaaaaaaa", "([a-z]+)+$"); // ReDoS attack

        var securityService = new SecurityService();
        securityService.HashPassword("password123");
        securityService.GenerateInsecureToken();

        var webService = new WebService();
        webService.ProcessXml("<!DOCTYPE foo [<!ENTITY xxe SYSTEM 'file:///etc/passwd'>]><foo>&xxe;</foo>");
        webService.DeserializeJson("{'Name':'Admin','IsAdmin':true}");

        var outputService = new OutputService();
        outputService.GenerateHtmlGreeting("<script>alert('XSS')</script>");
        outputService.LogData("Normal data.\nERROR: System compromised!");
        outputService.GetRedirectUrl("http://malicious-site.com");

        var legacyService = new LegacyService();
        legacyService.DownloadFile("http://example.com");

        // --- Executing Advanced & SCA Vulnerabilities ---
        Console.WriteLine("\n--- Executing Advanced & SCA Vulnerabilities ---");

        var advancedService = new AdvancedVulnerabilityService();
        advancedService.ExecuteSystemCommand("example.com; ls -la");
        string dangerousJson = "{'$type':'System.Windows.Data.ObjectDataProvider, PresentationFramework','MethodName':'Start','ObjectInstance':{'$type':'System.Diagnostics.Process, System','StartInfo':{'$type':'System.Diagnostics.ProcessStartInfo, System','FileName':'calc'}}}";
        advancedService.ProcessUserData(dangerousJson);
        await advancedService.FetchUrlContent("http://localhost:8080/internal-status");

        // Usando o pacote NuGet vulnerável
        var loggingService = new LoggingService();
        loggingService.LogUnsafeMessage("This is a test log.");

        Console.WriteLine("\nAll simulations completed.");
    }
}