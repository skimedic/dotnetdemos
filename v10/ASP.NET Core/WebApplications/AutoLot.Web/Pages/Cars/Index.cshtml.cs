// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class IndexModel(
    IAppLogging appLogging,
    ICarDataService carDataService) : BasePageModel<Car>(appLogging, carDataService, "Inventory")
{
    public string MakeName { get; set; }
    public int? MakeId { get; set; }
    public IList<Car> CarRecords { get; set; }

    public async Task OnGetAsync(
        int? makeId,
        string makeName)
    {
        MakeId = makeId;
        MakeName = makeId.HasValue ? makeName : "All Makes";
        CarRecords = await carDataService.GetAllByMakeIdAsync(makeId);
    }
}