// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Dal - CarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Dal.Repos;

public class CarRepo : TemporalTableBaseRepo<Car>,
    ICarRepo
{
    public CarRepo(
        ApplicationDbContext context) : base(context)
    {
    }

    internal CarRepo(
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Car> BuildBaseQuery() =>
        Table.Include(c => c.MakeNavigation)
            .OrderBy(c => c.PetName);

    public override IQueryable<Car> GetAllAsQueryable() => BuildBaseQuery();

    public override IQueryable<Car> GetAllIgnoreQueryFiltersAsQueryable() =>
        BuildBaseQuery()
            .IgnoreQueryFilters();

    public override IQueryable<Car> GetAllIgnoreQueryFiltersAsQueryable(
        IEnumerable<string> filtersToIgnore) =>
        BuildBaseQuery()
            .IgnoreQueryFilters(
            [
                .. filtersToIgnore
            ]);

    public override Car Find(
        int? id) =>
        id == null
            ? null
            : BuildBaseQuery()
                .IgnoreQueryFilters()
                .FirstOrDefault(c => c.Id == id.Value);

    public override Car FindAsNoTracking(
        int id) =>
        BuildBaseQuery()
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);

    public override Car FindIgnoreQueryFilters(
        int id) =>
        BuildBaseQuery()
            .IgnoreQueryFilters()
            .FirstOrDefault(c => c.Id == id);

    public List<Car> GetAllByAsList(
        int makeId) =>
        GetAllByAsQueryable(makeId)
            .ToList();

    // Returns deferred IQueryable — DbContext must remain alive until materialized.
    public IQueryable<Car> GetAllByAsQueryable(
        int makeId) =>
        BuildBaseQuery()
            .Where(c => c.MakeId == makeId);

    public string GetPetName(
        int id)
    {
        var outParam =
            new SqlParameter(
                "@petName",
                SqlDbType.NVarChar,
                50) { Direction = ParameterDirection.Output };
        ExecuteParameterizedQuery(
            "EXEC GetPetName @id, @petName OUT",
            [
                new SqlParameter(
                    "@id",
                    id),
                outParam
            ]);
        return outParam.Value?.ToString();
    }

    public int SetAllDrivableCarsColorAndMakeId(
        string color,
        int makeId) =>
        ExecuteBulkUpdate(
            c => c.IsDrivable,
            s =>
                s.SetProperty(
                        c => c.Color,
                        color)
                    .SetProperty(
                        c => c.MakeId,
                        makeId));

    //public int SetAllDrivableCarsColorAndMakeId(string color, int makeId) =>
    //ExecuteBulkUpdate(c => c.IsDrivable, u =>
    //    u.SetProperty(c => c.Color, color)
    //        .SetProperty(c => c.MakeId, makeId)
    //);

    public int DeleteNonDrivableCars() => ExecuteBulkDelete(c => !c.IsDrivable);
}