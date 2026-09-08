// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - DalDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity>(
    IAppLogger appLogger,
    IBaseRepo<TEntity> baseRepo) : IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IAppLogger AppLoggerInstance = appLogger;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance = baseRepo;

    // The DAL is intentionally synchronous (EF Core DbContext doesn't support concurrent async
    // operations on a single instance). Task.FromResult wraps sync results without thread pool overhead.
    public Task<List<TEntity>> GetAllAsync() => Task.FromResult(BaseRepoInstance.GetAllAsList());

    public Task<TEntity> FindAsync(
        int id) =>
        Task.FromResult(BaseRepoInstance.Find(id));

    public Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true)
    {
        BaseRepoInstance.Update(
            entity,
            persist);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(
        TEntity entity,
        bool persist = true) =>
        Task.FromResult(
            BaseRepoInstance.Delete(
                entity,
                persist));

    public Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true)
    {
        BaseRepoInstance.Add(
            entity,
            persist);
        return Task.FromResult(entity);
    }
}