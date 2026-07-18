// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
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
        Exception innerException) : base(message, innerException)
    {
    }
}