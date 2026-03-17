// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - ITemporalTableBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface ITemporalTableBaseRepo<T> : IBaseRepo<T> where T : BaseEntity, new()
{
    IQueryable<TemporalViewModel<T>> GetAllHistory();

    IQueryable<TemporalViewModel<T>> GetHistoryAsOf(
        DateTime dateTime);

    IQueryable<TemporalViewModel<T>> GetHistoryBetween(
        DateTime startDateTime,
        DateTime endDateTime);

    IQueryable<TemporalViewModel<T>> GetHistoryContainedIn(
        DateTime startDateTime,
        DateTime endDateTime);

    IQueryable<TemporalViewModel<T>> GetHistoryFromTo(
        DateTime startDateTime,
        DateTime endDateTime);
}