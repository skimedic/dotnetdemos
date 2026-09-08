// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - MakeApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class MakeApiServiceWrapper(
    HttpClient client,
    IOptionsSnapshot<ApiServiceSettings> apiSettingsSnapshot) : ApiServiceWrapperBase<Make>(
        client,
        apiSettingsSnapshot,
        apiSettingsSnapshot.Value.MakeBaseUri),
    IMakeApiServiceWrapper;