namespace AutoLot.Services.DataServices.Interfaces;

public interface ICarDataService : IDataServiceBase<Car>
{
    Task<IQueryable<Car>> GetAllByMakeIdAsync(
        int? makeId);
}