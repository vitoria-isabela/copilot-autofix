using System.Net;

public class LegacyService
{
    /// <summary>
    /// This method uses an obsolete class (WebClient) to download a file.
    /// Copilot should suggest replacing it with the modern HttpClient.
    /// </summary>
    public void DownloadFile(string address)
    {
        using (WebClient client = new WebClient())
        {
            Console.WriteLine("Downloading file using obsolete WebClient...");
            client.DownloadFile(address, "localfile.html");
        }
    }
}