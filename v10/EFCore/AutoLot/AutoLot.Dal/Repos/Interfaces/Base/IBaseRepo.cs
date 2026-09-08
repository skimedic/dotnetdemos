// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - IBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

// The DAL is intentionally synchronous throughout. EF Core's DbContext does not support
// concurrent async operations on a single instance — awaiting multiple async repo calls
// against the same context would throw at runtime. The async surface lives in the
// Services layer (DalDataServiceBase), which wraps these sync calls. Students add async
// to their service layer once they understand why it can't live here.
public interface IBaseRepo<T> : IBaseViewRepo<T> where T : BaseEntity, new()
{
    T Find(
        int? id);

    T FindAsNoTracking(
        int id);

    T FindIgnoreQueryFilters(
        int id);

    void ExecuteParameterizedQuery(
        string sql,
        object[] sqlParametersObjects);

    int Add(
        T entity,
        bool persist = true);

    int AddRange(
        IList<T> entities,
        bool persist = true);

    int Update(
        T entity,
        bool persist = true);

    int UpdateRange(
        IList<T> entities,
        bool persist = true);

    int Delete(
        int id,
        long timeStamp,
        bool persist = true);

    int Delete(
        T entity,
        bool persist = true);

    int DeleteRange(
        IList<T> entities,
        bool persist = true);

    int ExecuteBulkUpdate(
        Expression<Func<T, bool>> whereClause,
        Action<UpdateSettersBuilder<T>> setPropertyCalls);

    int ExecuteBulkDelete(
        Expression<Func<T, bool>> whereClause);

    int SaveChanges();
}