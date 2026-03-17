// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - MakeRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos;

public class MakeRepo : TemporalTableBaseRepo<Make>, IMakeRepo
{
    public MakeRepo(ApplicationDbContext context) : base(context) { }
    internal MakeRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    internal IOrderedQueryable<Make> BuildBaseQuery() => Table.OrderBy(m => m.Name);

    public override IQueryable<Make> GetAll() => BuildBaseQuery();
    public override IQueryable<Make> GetAllIgnoreQueryFilters() => BuildBaseQuery().IgnoreQueryFilters();
    public override IQueryable<Make> GetAllIgnoreQueryFilters(string[] filtersToIgnore) => BuildBaseQuery().IgnoreQueryFilters(filtersToIgnore);
}
