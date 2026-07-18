// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(
    IAppLogging appLogging,
    ICarDataService carDataService) : BasePageModel<Car>(appLogging, carDataService, "Details")
{
    public async Task OnGetAsync(
        int? id)
    {
        await GetOneEntityAsync(id);
    }
}