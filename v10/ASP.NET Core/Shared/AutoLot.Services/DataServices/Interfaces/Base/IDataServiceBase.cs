// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - IDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.DataServices.Interfaces.Base;

public interface IDataServiceBase<TEntity> where TEntity : BaseEntity, new()
{
    Task<List<TEntity>> GetAllAsync();

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