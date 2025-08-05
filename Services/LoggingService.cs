using log4net;
using log4net.Config;

public class LoggingService
{
    private static readonly ILog log = LogManager.GetLogger(typeof(LoggingService));

    public LoggingService()
    {
        BasicConfigurator.Configure();
    }

    /// <summary>
    /// VULNERABILITY (SCA - HIGH): Use of Component with Known Vulnerabilities.
    /// This method uses log4net version 2.0.10, which has publicly disclosed vulnerabilities.
    /// Snyk Open Source will detect this package usage.
    /// </summary>
    public void LogUnsafeMessage(string message)
    {
        log.Info("Logging a message with a vulnerable library: " + message);
    }
}