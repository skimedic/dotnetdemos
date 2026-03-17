// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - ApiDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.DataServices.Api.Base;

public abstract class ApiDataServiceBase<TEntity>(
    IAppLogging appLogging,
    IApiServiceWrapperBase<TEntity> serviceWrapperBase)
    : IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IApiServiceWrapperBase<TEntity> ServiceWrapper = serviceWrapperBase;
    protected readonly IAppLogging AppLoggingInstance = appLogging;

    public async Task<IQueryable<TEntity>> GetAllAsync()
        => (await ServiceWrapper.GetAllEntitiesAsync()).AsQueryable();

    public async Task<TEntity> FindAsync(
        int id)
        => await ServiceWrapper.GetEntityAsync(id);

    public async Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true)
        => await ServiceWrapper.UpdateEntityAsync(entity);

    public async Task DeleteAsync(
        TEntity entity,
        bool persist = true)
        => await ServiceWrapper.DeleteEntityAsync(entity);

    public async Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true)
        => await ServiceWrapper.AddEntityAsync(entity);
}