// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - IBaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface IBaseViewRepo<T> : IDisposable where T : class, new()
{
    IQueryable<T> ExecuteSqlString(
        string sql);

    // Returns a materialized list; safe to use after the DbContext is disposed.
    IList<T> GetAllAsList();
    IList<T> GetAllIgnoreQueryFiltersAsList();

    IList<T> GetAllIgnoreQueryFiltersAsList(
        string[] filtersToIgnore);

    // Returns an IQueryable that defers execution — the DbContext must remain alive
    // until the query is materialized (e.g., .ToList(), iteration, or JSON serialization).
    IQueryable<T> GetAllAsQueryable();
    IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable();

    IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable(
        string[] filtersToIgnore);
}