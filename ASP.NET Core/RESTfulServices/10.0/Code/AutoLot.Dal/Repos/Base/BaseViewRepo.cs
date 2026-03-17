// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - BaseViewRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class BaseViewRepo<T> : IBaseViewRepo<T> where T : class, new()
{
    private readonly bool _disposeContext;
    public DbSet<T> Table { get; }
    public ApplicationDbContext Context { get; }

    protected BaseViewRepo(
        ApplicationDbContext context)
        => (Context, Table, _disposeContext) = (context, context.Set<T>(), false);

    protected BaseViewRepo(
        DbContextOptions<ApplicationDbContext> options)
        : this(new ApplicationDbContext(options))
        => _disposeContext = true;

    public IQueryable<T> ExecuteSqlString(
        string sql) => Table.FromSqlRaw(sql);

    public virtual IQueryable<T> GetAll() => Table;
    public virtual IQueryable<T> GetAllIgnoreQueryFilters() => Table.IgnoreQueryFilters();

    public virtual IQueryable<T> GetAllIgnoreQueryFilters(
        string[] filtersToIgnore) => Table.IgnoreQueryFilters(filtersToIgnore);

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