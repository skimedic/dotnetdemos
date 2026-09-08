// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class IndexModel(
    IAppLogger appLogger,
    ICarDataService carDataService) : BasePageModel<Car>(
    appLogger,
    carDataService,
    "Inventory")
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