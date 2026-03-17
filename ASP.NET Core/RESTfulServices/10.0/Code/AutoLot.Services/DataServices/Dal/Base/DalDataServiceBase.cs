namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity>(
    IAppLogging appLoggingInstance,
    IBaseRepo<TEntity> baseRepoInstance)
    : IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLoggingInstance;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance = baseRepoInstance;

    public virtual async Task<IQueryable<TEntity>> GetAllAsync() => await Task.Run(() => BaseRepoInstance.GetAll());

    public virtual async Task<TEntity> FindAsync(
        int id) => await Task.Run(() => BaseRepoInstance.Find(id));

    public virtual async Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true)
    {
        return await Task.Run(() =>
        {
            BaseRepoInstance.Update(entity, persist);
            return entity;
        });
    }

    public virtual async Task DeleteAsync(
        TEntity entity,
        bool persist = true) => await Task.Run(() => BaseRepoInstance.Delete(entity, persist));

    public virtual async Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true)
    {
        return await Task.Run(() =>
        {
            BaseRepoInstance.Add(entity, persist);
            return entity;
        });
    }

    //implemented ghost method since it won’t be used by the API data service
    public virtual void ResetChangeTracker()
    {
    }
}