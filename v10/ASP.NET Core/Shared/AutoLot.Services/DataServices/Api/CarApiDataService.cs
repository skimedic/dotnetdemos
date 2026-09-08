// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class CarApiDataService(
    IAppLogger appLogger,
    ICarApiServiceWrapper carServiceWrapper) : ApiDataServiceBase<Car>(
        appLogger,
        carServiceWrapper),
    ICarDataService
{
    public Task<List<Car>> GetAllByMakeIdAsync(
        int? makeId) =>
        makeId.HasValue ? carServiceWrapper.GetCarsByMakeAsync(makeId.Value) : GetAllAsync();
}