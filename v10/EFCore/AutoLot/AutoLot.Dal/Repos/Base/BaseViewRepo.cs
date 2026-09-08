// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - BaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class BaseViewRepo<T>(
    ApplicationDbContext context) : IBaseViewRepo<T> where T : class
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

    public virtual List<T> GetAllAsList() =>
        GetAllAsQueryable()
            .ToList();

    public virtual List<T> GetAllIgnoreQueryFiltersAsList() =>
        GetAllIgnoreQueryFiltersAsQueryable()
            .ToList();

    public virtual List<T> GetAllIgnoreQueryFiltersAsList(
        IEnumerable<string> filtersToIgnore) =>
        GetAllIgnoreQueryFiltersAsQueryable(filtersToIgnore)
            .ToList();

    // The IQueryable overloads below defer execution — the DbContext must remain alive
    // until the query is materialized. Use the AsList variants when the caller does not
    // need to compose additional query operators (filtering, paging, projection).
    public virtual IQueryable<T> GetAllAsQueryable() => Table;
    public virtual IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable() => Table.IgnoreQueryFilters();

    public virtual IQueryable<T> GetAllIgnoreQueryFiltersAsQueryable(
        IEnumerable<string> filtersToIgnore) =>
        Table.IgnoreQueryFilters(
        [
            .. filtersToIgnore
        ]);
}