// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class IndexModel(
    ICarRepo carRepo,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carRepo, "Inventory")
{
    public string MakeName { get; set; }
    public int? MakeId { get; set; }
    public IList<Car> CarRecords { get; set; }

    public void OnGet(
        int? makeId,
        string makeName)
    {
        MakeId = makeId;
        if (!makeId.HasValue)
        {
            MakeName = "All Makes";
            CarRecords = BaseRepoInstance.GetAllIgnoreQueryFilters().ToList();
        }
        else
        {
            MakeName = makeName;
            CarRecords = ((ICarRepo)BaseRepoInstance).GetAllBy(makeId.Value).ToList();
        }
    }
}