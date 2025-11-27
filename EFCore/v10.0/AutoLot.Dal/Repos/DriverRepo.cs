// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - DriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Dal.Repos;

public class DriverRepo : BaseRepo<Driver>, IDriverRepo
{
    public DriverRepo(ApplicationDbContext context) : base(context) { }
    internal DriverRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    internal IOrderedQueryable<Driver> BuildBaseQuery() =>
        Table.OrderBy(d => d.PersonInformation.LastName).ThenBy(d => d.PersonInformation.FirstName);

    public override IQueryable<Driver> GetAll() => BuildBaseQuery();
    public override IQueryable<Driver> GetAllIgnoreQueryFilters() => BuildBaseQuery().IgnoreQueryFilters();
    public override IQueryable<Driver> GetAllIgnoreQueryFilters(string[] filtersToIgnore) => BuildBaseQuery().IgnoreQueryFilters(filtersToIgnore);
}
