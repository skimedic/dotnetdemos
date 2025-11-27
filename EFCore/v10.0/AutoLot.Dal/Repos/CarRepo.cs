// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - CarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Dal.Repos;

public class CarRepo : BaseRepo<Car>, ICarRepo
{
    public CarRepo(ApplicationDbContext context) : base(context) { }
    internal CarRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    internal IOrderedQueryable<Car> BuildBaseQuery() =>
        Table.Include(c => c.MakeNavigation).OrderBy(c => c.PetName);

    public override IQueryable<Car> GetAll() => BuildBaseQuery();
    public override IQueryable<Car> GetAllIgnoreQueryFilters() => BuildBaseQuery().IgnoreQueryFilters();
    public override IQueryable<Car> GetAllIgnoreQueryFilters(string[] filtersToIgnore) => BuildBaseQuery().IgnoreQueryFilters(filtersToIgnore);
    public override Car Find(int? id) => id == null ? null : BuildBaseQuery().IgnoreQueryFilters().FirstOrDefault(c => c.Id == id.Value);

    public IQueryable<Car> GetAllBy(int makeId) => BuildBaseQuery().Where(c => c.MakeId == makeId);

    public string GetPetName(
        int id)
        {
        var outParam = new SqlParameter("@petName", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
        ExecuteParameterizedQuery("EXEC GetPetName @id, @petName OUT",
            [new SqlParameter("@id", id), outParam]);
        return outParam.Value?.ToString();
    }
    public int SetAllDrivableCarsColorAndMakeId(
        string color,
        int makeId)
        => ExecuteBulkUpdate(c => c.IsDrivable,
            s => s.SetProperty(c => c.Color, color).SetProperty(c => c.MakeId, makeId));
    
    public int DeleteNonDrivableCars()
        => ExecuteBulkDelete(c => !c.IsDrivable);
}