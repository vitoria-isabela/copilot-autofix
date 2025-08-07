public class OutputService
{
    public string GenerateHtmlGreeting(string name)
    {
        /// <summary>
        /// VULNERABILITY (HIGH): Cross-Site Scripting (XSS).
        /// The 'name' input is directly embedded into HTML without encoding.
        /// </summary>
        return "<h1>Welcome, " + name + "!</h1>";
    }

    public void LogData(string data)
    {
        /// <summary>
        /// VULNERABILITY (LOW): Log Injection.
        /// If 'data' contains newline characters, it can be used to forge log entries.
        /// </summary>
        Console.WriteLine("INFO: User data received: " + data);
    }

    public string GetRedirectUrl(string url)
    {
        /// <summary>
        /// VULNERABILITY (MEDIUM): Open Redirect.
        /// The application redirects to a URL provided by the user, which could
        /// point to a malicious site.
        /// </summary>
        return url;
    }
}