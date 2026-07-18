namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity>(
    IAppLogging appLoggingInstance,
    IBaseRepo<TEntity> baseRepoInstance) : IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLoggingInstance;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance = baseRepoInstance;

    // The DAL is intentionally synchronous (EF Core DbContext doesn't support concurrent async
    // operations on a single instance). Task.FromResult wraps sync results without thread pool overhead.
    public Task<IList<TEntity>> GetAllAsync() => Task.FromResult(BaseRepoInstance.GetAllAsList());

    public Task<TEntity> FindAsync(
        int id) =>
        Task.FromResult(BaseRepoInstance.Find(id));

    public Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true)
    {
        BaseRepoInstance.Update(entity, persist);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(
        TEntity entity,
        bool persist = true) =>
        Task.FromResult(BaseRepoInstance.Delete(entity, persist));

    public Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true)
    {
        BaseRepoInstance.Add(entity, persist);
        return Task.FromResult(entity);
    }
}