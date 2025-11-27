// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - AppLogging.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Services.Logging;

public sealed class AppLogging(
    ILogger<AppLogging> logger) : IAppLogging
{
    internal void LogWithException(
        string memberName,
        string filePath,
        int lineNumber,
        string message,
        Exception ex,
        Action<Exception, string, object[]> logAction)
    {
        var disposables = new List<IDisposable>
        {
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("FilePath", filePath),
            LogContext.PushProperty("LineNumber", lineNumber)
        };
        try
        {
            logAction(ex, message, Array.Empty<object>());
        }
        finally
        {
            foreach (var d in disposables)
            {
                d.Dispose();
            }
        }
    }

    internal void LogWithoutException(
        string memberName,
        string filePath,
        int lineNumber,
        string message,
        Action<string, object[]> logAction)
    {
        var disposables = new List<IDisposable>
        {
            LogContext.PushProperty("MemberName", memberName),
            LogContext.PushProperty("FilePath", filePath),
            LogContext.PushProperty("LineNumber", lineNumber)
        };
        try
        {
            logAction(message, Array.Empty<object>());
        }
        finally
        {
            foreach (var d in disposables)
            {
                d.Dispose();
            }
        }
    }

    public void LogAppError(
        Exception exception,
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithException(memberName, filePath, lineNumber, message, exception, logger.LogError);

    public void LogAppError(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogError);

    public void LogAppCritical(
        Exception exception,
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithException(memberName, filePath, lineNumber, message, exception, logger.LogCritical);

    public void LogAppCritical(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogCritical);

    public void LogAppDebug(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogDebug);

    public void LogAppTrace(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogTrace);

    public void LogAppInformation(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogInformation);

    public void LogAppWarning(
        string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
        => LogWithoutException(memberName, filePath, lineNumber, message, logger.LogWarning);
}