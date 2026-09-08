// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DeleteModel(
    IAppLogger appLogger,
    ICarDataService carDataService) : BasePageModel<Car>(
    appLogger,
    carDataService,
    "Delete")
{
    public async Task OnGetAsync(
        int? id)
    {
        await GetOneEntityAsync(id);
    }

    public Task<IActionResult> OnPostAsync(
        int id) =>
        DeleteOneEntityAsync(id);
}