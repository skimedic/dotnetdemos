// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - CarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class CarApiServiceWrapper(
    HttpClient client,
    IOptionsSnapshot<ApiServiceSettings> apiSettingsSnapshot) : ApiServiceWrapperBase<Car>(
        client,
        apiSettingsSnapshot,
        apiSettingsSnapshot.Value.CarBaseUri),
    ICarApiServiceWrapper
{
    public async Task<List<Car>> GetCarsByMakeAsync(
        int id)
    {
        var response =
            await Client.GetAsync($"{ApiSettings.BaseUri}{ApiSettings.CarBaseUri}/bymake/{id}?v={ApiVersion}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<List<Car>>();
        return result;
    }
}