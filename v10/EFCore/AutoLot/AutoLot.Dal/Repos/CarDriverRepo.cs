// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - CarDriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos;

public class CarDriverRepo : TemporalTableBaseRepo<CarDriver>,
    ICarDriverRepo
{
    public CarDriverRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    internal CarDriverRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IIncludableQueryable<CarDriver, Driver> BuildBaseQuery() =>
        Table.Include(cd => cd.CarNavigation)
            .Include(cd => cd.DriverNavigation);

    public override IQueryable<CarDriver> GetAllAsQueryable() => BuildBaseQuery();

    public override IQueryable<CarDriver> GetAllIgnoreQueryFiltersAsQueryable() =>
        BuildBaseQuery()
            .IgnoreQueryFilters();

    public override IQueryable<CarDriver> GetAllIgnoreQueryFiltersAsQueryable(
        IEnumerable<string> filtersToIgnore) =>
        BuildBaseQuery()
            .IgnoreQueryFilters(
            [
                .. filtersToIgnore
            ]);

    public override CarDriver Find(
        int? id) =>
        id == null
            ? null
            : BuildBaseQuery()
                .IgnoreQueryFilters()
                .FirstOrDefault(cd => cd.Id == id.Value);

    public override CarDriver FindAsNoTracking(
        int id) =>
        BuildBaseQuery()
            .AsNoTracking()
            .FirstOrDefault(cd => cd.Id == id);

    public override CarDriver FindIgnoreQueryFilters(
        int id) =>
        BuildBaseQuery()
            .IgnoreQueryFilters()
            .FirstOrDefault(cd => cd.Id == id);
}