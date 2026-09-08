// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - IBaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface IBaseViewRepo<T> where T : class
{
    IQueryable<T> ExecuteSqlString(
        string sql);

    // Returns a materialized list; safe to use after the DbContext is disposed.
    List<T> GetAllAsList();
    List<T> GetAllIgnoreQueryFiltersAsList();

    List<T> GetAllIgnoreQueryFiltersAsList(
        IEnumerable<string> filtersToIgnore);

    // Returns an IQueryable that defers execution — the DbContext must remain alive
    // until the query is materialized (e.g., .ToList(), iteration, or JSON serialization).
    IQueryable<T> GetAllAsQueryable();
    IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable();

    IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable(
        IEnumerable<string> filtersToIgnore);
}