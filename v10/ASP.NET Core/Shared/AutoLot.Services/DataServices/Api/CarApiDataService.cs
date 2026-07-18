// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class CarApiDataService(
    IAppLogging appLogging,
    ICarApiServiceWrapper carServiceWrapper) : ApiDataServiceBase<Car>(appLogging, carServiceWrapper),
    ICarDataService
{
    public Task<IList<Car>> GetAllByMakeIdAsync(
        int? makeId) =>
        makeId.HasValue ? carServiceWrapper.GetCarsByMakeAsync(makeId.Value) : GetAllAsync();
}