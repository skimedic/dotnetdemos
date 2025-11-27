// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CarDriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Dal.Repos;

public class CarDriverRepo : BaseRepo<CarDriver>, ICarDriverRepo
{
    public CarDriverRepo(ApplicationDbContext context) : base(context) { }
    internal CarDriverRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    internal IIncludableQueryable<CarDriver, Driver> BuildBaseQuery() =>
        Table.Include(cd => cd.CarNavigation).Include(cd => cd.DriverNavigation);

    public override IQueryable<CarDriver> GetAll() => BuildBaseQuery();
    public override IQueryable<CarDriver> GetAllIgnoreQueryFilters() => BuildBaseQuery().IgnoreQueryFilters();
    public override IQueryable<CarDriver> GetAllIgnoreQueryFilters(string[] filtersToIgnore) => BuildBaseQuery().IgnoreQueryFilters(filtersToIgnore);
    public override CarDriver Find(int? id) => id == null ? null : BuildBaseQuery().IgnoreQueryFilters().FirstOrDefault(cd => cd.Id == id.Value);
}
