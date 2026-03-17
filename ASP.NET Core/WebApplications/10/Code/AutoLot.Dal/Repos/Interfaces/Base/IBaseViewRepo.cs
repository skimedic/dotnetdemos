// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - IBaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface IBaseViewRepo<T> : IDisposable where T : class, new()
{
    ApplicationDbContext Context { get; }

    IQueryable<T> ExecuteSqlString(
        string sql);

    IQueryable<T> GetAll();
    IQueryable<T> GetAllIgnoreQueryFilters();

    IQueryable<T> GetAllIgnoreQueryFilters(
        string[] filtersToIgnore);
}