// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - TemporalTableBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos.Base;

public class TemporalTableBaseRepo<T> : BaseRepo<T>, ITemporalTableBaseRepo<T> where T : BaseEntity, new()
{
    public TemporalTableBaseRepo(ApplicationDbContext context) : base(context) { }
    public TemporalTableBaseRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public IQueryable<TemporalViewModel<T>> GetAllHistory() => ExecuteQuery(Table.TemporalAll());

    public IQueryable<TemporalViewModel<T>> GetHistoryAsOf(DateTime dateTime) => ExecuteQuery(Table.TemporalAsOf(ConvertToUtc(dateTime)));

    public IQueryable<TemporalViewModel<T>> GetHistoryBetween(DateTime startDateTime, DateTime endDateTime) => ExecuteQuery(Table.TemporalBetween(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));

    public IQueryable<TemporalViewModel<T>> GetHistoryContainedIn(DateTime startDateTime, DateTime endDateTime) => ExecuteQuery(Table.TemporalContainedIn(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));

    public IQueryable<TemporalViewModel<T>> GetHistoryFromTo(DateTime startDateTime, DateTime endDateTime) => ExecuteQuery(Table.TemporalFromTo(ConvertToUtc(startDateTime), ConvertToUtc(endDateTime)));

    internal DateTime ConvertToUtc(DateTime dateTime) => TimeZoneInfo.ConvertTimeToUtc(dateTime);

    internal IQueryable<TemporalViewModel<T>> ExecuteQuery(IQueryable<T> query) =>
        query.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
             .Select(e => new TemporalViewModel<T>
             {
                 Entity = e,
                 ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
                 ValidTo = EF.Property<DateTime>(e, "ValidTo")
             });
}
