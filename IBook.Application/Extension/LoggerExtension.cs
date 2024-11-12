using Microsoft.Extensions.Logging;

namespace IBook.Application.Extension;

public static class LoggerExtension
{
    public static void LogInformationDateTime(this ILogger logger, string message)
    {
        logger.LogInformation(message + $" DateTime: {DateTime.Now}");
    }
}