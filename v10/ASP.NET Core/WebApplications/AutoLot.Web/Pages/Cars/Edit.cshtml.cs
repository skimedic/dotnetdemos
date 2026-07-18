// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class EditModel(
    IAppLogging appLogging,
    ICarDataService carDataService,
    IMakeDataService makeDataService) : BasePageModel<Car>(appLogging, carDataService, "Edit")
{
    protected override async Task GetLookupValuesAsync() =>
        LookupValues =
            new SelectList((await makeDataService.GetAllAsync()).OrderBy(m => m.Name), nameof(Make.Id),
                nameof(Make.Name));

    public async Task OnGetAsync(
        int? id)
    {
        await GetOneEntityAsync(id);
        await GetLookupValuesAsync();
    }

    public Task<IActionResult> OnPostAsync(
        int id) =>
        SaveOneEntityWithLookupAsync(carDataService.UpdateAsync);
}