// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ITemporalTableBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface ITemporalTableBaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity, new()
{
    IQueryable<TemporalViewModel<TEntity>> GetAllHistory();

    IQueryable<TemporalViewModel<TEntity>> GetHistoryAsOf(
        DateTime dateTime);

    IQueryable<TemporalViewModel<TEntity>> GetHistoryBetween(
        DateTime startDateTime,
        DateTime endDateTime);

    IQueryable<TemporalViewModel<TEntity>> GetHistoryContainedIn(
        DateTime startDateTime,
        DateTime endDateTime);

    IQueryable<TemporalViewModel<TEntity>> GetHistoryFromTo(
        DateTime startDateTime,
        DateTime endDateTime);
}