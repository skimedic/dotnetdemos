// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - ICarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Interfaces;

public interface ICarDataService : IDataServiceBase<Car>
{
    Task<List<Car>> GetAllByMakeIdAsync(
        int? makeId);
}