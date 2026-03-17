// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - MakeApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class MakeApiServiceWrapper(
    HttpClient client,
    IOptionsSnapshot<ApiServiceSettings> apiSettingsSnapshot)
    : ApiServiceWrapperBase<Make>(client, apiSettingsSnapshot, apiSettingsSnapshot.Value.MakeBaseUri),
        IMakeApiServiceWrapper
{
}