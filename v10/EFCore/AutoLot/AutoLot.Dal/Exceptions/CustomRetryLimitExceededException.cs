// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CustomRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomRetryLimitExceededException : CustomException
{
    public CustomRetryLimitExceededException()
    {
    }

    public CustomRetryLimitExceededException(
        string message) : base(message)
    {
    }

    public CustomRetryLimitExceededException(
        string message,
        RetryLimitExceededException innerException) : base(message, innerException)
    {
    }
}