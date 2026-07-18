namespace AutoLot.Services.DataServices.Interfaces;

public interface ICarDataService : IDataServiceBase<Car>
{
    Task<IList<Car>> GetAllByMakeIdAsync(
        int? makeId);
}