// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - BaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class BaseRepo<T> : BaseViewRepo<T>, IBaseRepo<T> where T : BaseEntity, new()
{
    protected BaseRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    protected BaseRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual T Find(
        int? id) => id == null ? null : Table.Find(id.Value);

    public virtual T FindAsNoTracking(
        int id) =>
        Table.AsNoTrackingWithIdentityResolution().FirstOrDefault(e => e.Id == id);

    public virtual T FindIgnoreQueryFilters(
        int id) =>
        Table.IgnoreQueryFilters().FirstOrDefault(e => e.Id == id);

    public virtual void ExecuteParameterizedQuery(
        string sql,
        object[] sqlParametersObjects) =>
        Context.Database.ExecuteSqlRaw(sql, sqlParametersObjects);

    public virtual int Add(
        T entity,
        bool persist = true)
    {
        Table.Add(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int AddRange(
        IQueryable<T> entities,
        bool persist = true)
    {
        Table.AddRange(entities);
        return persist ? SaveChanges() : 0;
    }

    public virtual int Update(
        T entity,
        bool persist = true)
    {
        Table.Update(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int UpdateRange(
        IQueryable<T> entities,
        bool persist = true)
    {
        Table.UpdateRange(entities);
        return persist ? SaveChanges() : 0;
    }

    //This delete shows using entity state to eliminate a query
    public virtual int Delete(
        int id,
        long timeStamp,
        bool persist = true)
    {
        var entity = new T { Id = id, TimeStamp = timeStamp };
        Context.Entry(entity).State = EntityState.Deleted;
        return persist ? SaveChanges() : 0;
    }

    public virtual int Delete(
        T entity,
        bool persist = true)
    {
        Table.Remove(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int DeleteRange(
        IQueryable<T> entities,
        bool persist = true)
    {
        Table.RemoveRange(entities);
        return persist ? SaveChanges() : 0;
    }

    public virtual int ExecuteBulkUpdate(
        Expression<Func<T, bool>> whereClause,
        Action<UpdateSettersBuilder<T>> setPropertyCalls)
        => Table.IgnoreQueryFilters().Where(whereClause).ExecuteUpdate(setPropertyCalls);

    public virtual int ExecuteBulkDelete(
        Expression<Func<T, bool>> whereClause)
        => Table.IgnoreQueryFilters().Where(whereClause).ExecuteDelete();

    public virtual int SaveChanges()
    {
        try
        {
            return Context.SaveChanges();
        }
        catch (CustomException)
        {
            //Should handle intelligently - already logged
            throw;
        }
        catch (Exception ex)
        {
            //Should log and handle intelligently
            throw new CustomException("An error occurred updating the database", ex);
        }
    }
}