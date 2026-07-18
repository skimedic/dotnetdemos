// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Services - ApiDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/04
// ==================================

namespace AutoLot.Services.DataServices.Api.Base;

public abstract class ApiDataServiceBase<TEntity>(
    IAppLogging appLogging,
    IApiServiceWrapperBase<TEntity> serviceWrapperBase) : IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IApiServiceWrapperBase<TEntity> ServiceWrapper = serviceWrapperBase;
    protected readonly IAppLogging AppLoggingInstance = appLogging;

    public Task<IList<TEntity>> GetAllAsync() => ServiceWrapper.GetAllEntitiesAsync();

    public Task<TEntity> FindAsync(
        int id) =>
        ServiceWrapper.GetEntityAsync(id);

    public Task<TEntity> UpdateAsync(
        TEntity entity,
        bool persist = true) =>
        ServiceWrapper.UpdateEntityAsync(entity);

    public Task DeleteAsync(
        TEntity entity,
        bool persist = true) =>
        ServiceWrapper.DeleteEntityAsync(entity);

    public Task<TEntity> AddAsync(
        TEntity entity,
        bool persist = true) =>
        ServiceWrapper.AddEntityAsync(entity);
}