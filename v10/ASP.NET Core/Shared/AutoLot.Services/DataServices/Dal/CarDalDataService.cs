namespace AutoLot.Services.DataServices.Dal;

public class CarDalDataService(
    IAppLogging appLoggingInstance,
    ICarRepo carRepoInstance) : DalDataServiceBase<Car>(appLoggingInstance, carRepoInstance),
    ICarDataService
{
    // Typed reference avoids repeated downcasting from IBaseRepo<Car>.
    private readonly ICarRepo _carRepo = carRepoInstance;

    public Task<IList<Car>> GetAllByMakeIdAsync(
        int? makeId) =>
        Task.FromResult(makeId.HasValue
            ? _carRepo.GetAllByAsList(makeId.Value)
            : _carRepo.GetAllIgnoreQueryFiltersAsList());
}