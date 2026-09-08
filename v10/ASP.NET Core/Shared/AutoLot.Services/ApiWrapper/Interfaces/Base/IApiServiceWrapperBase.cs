// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - IApiServiceWrapperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.ApiWrapper.Interfaces.Base;

public interface IApiServiceWrapperBase<TEntity> where TEntity : BaseEntity, new()
{
    Task<List<TEntity>> GetAllEntitiesAsync();

    Task<TEntity> GetEntityAsync(
        int id);

    Task<TEntity> AddEntityAsync(
        TEntity entity);

    Task<TEntity> UpdateEntityAsync(
        TEntity entity);

    Task DeleteEntityAsync(
        TEntity entity);
}