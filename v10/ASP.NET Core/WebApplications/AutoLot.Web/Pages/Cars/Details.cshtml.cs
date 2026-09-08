// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(
    IAppLogger appLogger,
    ICarDataService carDataService) : BasePageModel<Car>(
    appLogger,
    carDataService,
    "Details")
{
    public async Task OnGetAsync(
        int? id)
    {
        await GetOneEntityAsync(id);
    }
}