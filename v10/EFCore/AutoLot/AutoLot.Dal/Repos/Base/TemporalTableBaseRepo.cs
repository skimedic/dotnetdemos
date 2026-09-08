// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - TemporalTableBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class TemporalTableBaseRepo<TEntity> : BaseRepo<TEntity>,
    ITemporalTableBaseRepo<TEntity> where TEntity : BaseEntity, new()
{
    protected TemporalTableBaseRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    protected TemporalTableBaseRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal DateTime ConvertToUtc(
        DateTime dateTime) =>
        TimeZoneInfo.ConvertTimeToUtc(
            dateTime,
            TimeZoneInfo.Local);

    internal IQueryable<TemporalViewModel<TEntity>> ExecuteQuery(
        IQueryable<TEntity> query) =>
        query.OrderBy(e =>
            EF.Property<DateTime>(
                e,
                "ValidFrom"))
            .Select(e =>
            new TemporalViewModel<TEntity>
            {
                Entity = e,
                ValidFrom =
                    EF.Property<DateTime>(
                        e,
                        "ValidFrom"),
                ValidTo =
                    EF.Property<DateTime>(
                        e,
                        "ValidTo")
            });

    public IQueryable<TemporalViewModel<TEntity>> GetAllHistory() => ExecuteQuery(Table.TemporalAll());

    public IQueryable<TemporalViewModel<TEntity>> GetHistoryAsOf(
        DateTime dateTime) =>
        ExecuteQuery(Table.TemporalAsOf(ConvertToUtc(dateTime)));

    public IQueryable<TemporalViewModel<TEntity>> GetHistoryBetween(
        DateTime startDateTime,
        DateTime endDateTime) =>
        ExecuteQuery(
            Table.TemporalBetween(
                ConvertToUtc(startDateTime),
                ConvertToUtc(endDateTime)));

    public IQueryable<TemporalViewModel<TEntity>> GetHistoryContainedIn(
        DateTime startDateTime,
        DateTime endDateTime) =>
        ExecuteQuery(
            Table.TemporalContainedIn(
                ConvertToUtc(startDateTime),
                ConvertToUtc(endDateTime)));

    public IQueryable<TemporalViewModel<TEntity>> GetHistoryFromTo(
        DateTime startDateTime,
        DateTime endDateTime) =>
        ExecuteQuery(
            Table.TemporalFromTo(
                ConvertToUtc(startDateTime),
                ConvertToUtc(endDateTime)));
}