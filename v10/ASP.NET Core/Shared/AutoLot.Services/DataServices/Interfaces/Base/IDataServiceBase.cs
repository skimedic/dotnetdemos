namespace AutoLot.Services.DataServices.Interfaces.Base;

public interface IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    Task<IList<TEntity>> GetAllAsync();

    Task<TEntity> FindAsync(
        int id);

    Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true);

    Task DeleteAsync(
        TEntity entity,
        bool persist = true);

    Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true);
}