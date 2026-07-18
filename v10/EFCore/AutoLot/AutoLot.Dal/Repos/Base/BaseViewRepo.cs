// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - BaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class BaseViewRepo<T>(
    ApplicationDbContext context) : IBaseViewRepo<T> where T : class, new()
{
    private readonly bool _disposeContext = false;
    protected DbSet<T> Table { get; } = context.Set<T>();
    protected ApplicationDbContext Context { get; } = context;

    protected BaseViewRepo(
        DbContextOptions<ApplicationDbContext> options) : this(new ApplicationDbContext(options)) =>
        _disposeContext = true;

    public IQueryable<T> ExecuteSqlString(
        string sql) =>
        Table.FromSqlRaw(sql);

    public virtual IList<T> GetAllAsList() => GetAllAsQueryable().ToList();
    public virtual IList<T> GetAllIgnoreQueryFiltersAsList() => GetAllIgnoreQueryFiltersAsQueryable().ToList();

    public virtual IList<T> GetAllIgnoreQueryFiltersAsList(
        string[] filtersToIgnore) =>
        GetAllIgnoreQueryFiltersAsQueryable(filtersToIgnore).ToList();

    // The IQueryable overloads below defer execution — the DbContext must remain alive
    // until the query is materialized. Use the AsList variants when the caller does not
    // need to compose additional query operators (filtering, paging, projection).
    public virtual IQueryable<T> GetAllAsQueryable() => Table;
    public virtual IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable() => Table.IgnoreQueryFilters();

    public virtual IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable(
        string[] filtersToIgnore) =>
        Table.IgnoreQueryFilters(filtersToIgnore);

    protected virtual void Dispose(
        bool disposing)
    {
        if (disposing && _disposeContext)
        {
            Context.Dispose();
        }
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}