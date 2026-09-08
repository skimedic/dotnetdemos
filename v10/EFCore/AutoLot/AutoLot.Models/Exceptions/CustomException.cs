// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Models - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Models.Exceptions;

public class CustomException : Exception
{
    public CustomException()
    {
    }

    public CustomException(
        string message) : base(message)
    {
    }

    public CustomException(
        string message,
        Exception innerException) : base(
        message,
        innerException)
    {
    }
}