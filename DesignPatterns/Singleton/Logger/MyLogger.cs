using System.Text;

namespace Singleton.Logger;

public sealed class MyLogger : IMyLogger
{
    private MyLogger() { }

    private static MyLogger? _logInstance = null;

    public static MyLogger GetLoggerInstance
    {
        get
        {
            if (_logInstance == null)
            {
                _logInstance = new MyLogger();
            }
            return _logInstance;
        }
    }

    public void LogException(string message)
    {
        // Create the dymamic file name
        string fileName = $"Exception_{DateTime.Now.ToString("yyyyMMdd")}.log";

        // Create the path where you want to create the Log File
        string logFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{fileName}";

        // Build the string object using stringbuilder for a better performance
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("........................");
        sb.AppendLine(DateTime.Now.ToString());
        sb.AppendLine(message);

        // Write the stringbuilder message into the log file path using streamwritter object
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.Write(sb.ToString());
            writer.Flush();
        }
    }
}
