// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomDbUpdateException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomDbUpdateException : CustomException
{
    public CustomDbUpdateException()
    {
    }

    public CustomDbUpdateException(
        string message) : base(message)
    {
    }

    public CustomDbUpdateException(
        string message,
        DbUpdateException innerException) : base(message, innerException)
    {
    }
}