// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - IAppLogger.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.Logging.Interfaces;

public interface IAppLogger
{
    void LogAppError(
        Exception ex,
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppError(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppCritical(
        Exception ex,
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppCritical(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppDebug(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppTrace(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppInformation(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);

    void LogAppWarning(
        string message,
        [CallerMemberName]
        string memberName = "",
        [CallerFilePath]
        string filePath = "",
        [CallerLineNumber]
        int lineNumber = 0);
}