// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - MakeRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/18
// ==================================

namespace AutoLot.Dal.Repos;

public class MakeRepo : TemporalTableBaseRepo<Make>,
    IMakeRepo
{
    public MakeRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    internal MakeRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Make> BuildBaseQuery() => Table.OrderBy(m => m.Name);

    public override IQueryable<Make> GetAllAsQueryable() => BuildBaseQuery();

    public override IQueryable<Make> GetAllIgnoreQueryFiltersAsQueryable() =>
        BuildBaseQuery()
            .IgnoreQueryFilters();

    public override IQueryable<Make> GetAllIgnoreQueryFiltersAsQueryable(
        string[] filtersToIgnore) =>
        BuildBaseQuery()
            .IgnoreQueryFilters(filtersToIgnore);
}