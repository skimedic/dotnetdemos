// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Services.Utilities;
public static class StringExtensions
{
    extension(
        string value)
    {
        public string RemoveControllerSuffix()
        => value != null && value.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
            ? value[..^10]
            : value;
    }
}
