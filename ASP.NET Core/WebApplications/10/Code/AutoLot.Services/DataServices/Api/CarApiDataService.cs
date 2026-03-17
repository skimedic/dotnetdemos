// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class CarApiDataService(
    IAppLogging appLogging,
    ICarApiServiceWrapper serviceWrapper)
    : ApiDataServiceBase<Car>(appLogging, serviceWrapper), ICarDataService
{
    public async Task<IQueryable<Car>> GetAllByMakeIdAsync(
        int? makeId)
        => makeId.HasValue
            ? (await ((ICarApiServiceWrapper)ServiceWrapper).GetCarsByMakeAsync(makeId.Value)).AsQueryable()
            : await GetAllAsync();
}