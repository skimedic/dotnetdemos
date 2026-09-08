// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - DriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos;

public class DriverRepo : TemporalTableBaseRepo<Driver>,
    IDriverRepo
{
    public DriverRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    internal DriverRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Driver> BuildBaseQuery() =>
        Table.OrderBy(d => d.PersonInformation.LastName)
            .ThenBy(d => d.PersonInformation.FirstName);

    public override IQueryable<Driver> GetAllAsQueryable() => BuildBaseQuery();

    public override IQueryable<Driver> GetAllIgnoreQueryFiltersAsQueryable() =>
        BuildBaseQuery()
            .IgnoreQueryFilters();

    public override IQueryable<Driver> GetAllIgnoreQueryFiltersAsQueryable(
        IEnumerable<string> filtersToIgnore) =>
        BuildBaseQuery()
            .IgnoreQueryFilters(
            [
                .. filtersToIgnore
            ]);
}