// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - ApiServiceSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.ApiWrapper.Models;

public class ApiServiceSettings
{
    [Required]
    public string BaseUri { get; set; }
    [Required]
    public string CarBaseUri { get; set; }
    [Required]
    public string MakeBaseUri { get; set; }
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public string Status { get; set; }

    public string ApiVersion =>
        $"{MajorVersion}.{MinorVersion}" + (!string.IsNullOrEmpty(Status) ? $"-{Status}" : string.Empty);
}