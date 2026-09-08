// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - CarDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class CarDalDataService(
    IAppLogger appLogger,
    ICarRepo carRepo) : DalDataServiceBase<Car>(
        appLogger,
        carRepo),
    ICarDataService
{
    // Typed reference avoids repeated downcasting from IBaseRepo<Car>.
    private readonly ICarRepo _carRepo = carRepo;

    public Task<List<Car>> GetAllByMakeIdAsync(
        int? makeId) =>
        Task.FromResult(
            makeId.HasValue ? _carRepo.GetAllByAsList(makeId.Value) : _carRepo.GetAllIgnoreQueryFiltersAsList());
}