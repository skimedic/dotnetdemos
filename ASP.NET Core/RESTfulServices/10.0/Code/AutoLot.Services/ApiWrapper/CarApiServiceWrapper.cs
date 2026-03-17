// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - CarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class CarApiServiceWrapper(
    HttpClient client,
    IOptionsSnapshot<ApiServiceSettings> apiSettingsSnapshot)
    : ApiServiceWrapperBase<Car>(client, apiSettingsSnapshot, apiSettingsSnapshot.Value.CarBaseUri),
        ICarApiServiceWrapper
{
    public async Task<IList<Car>> GetCarsByMakeAsync(
        int id)
    {
        var response = await
            Client.GetAsync($"{ApiSettings.Uri}{ApiSettings.CarBaseUri}/bymake/{id}?v={ApiVersion}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IList<Car>>();
        return result;
    }
}