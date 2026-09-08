// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class CreateModel(
    IAppLogger appLogger,
    ICarDataService carDataService,
    IMakeDataService makeDataService) : BasePageModel<Car>(
    appLogger,
    carDataService,
    "Create")
{
    public async Task OnGetAsync()
    {
        await GetLookupValuesAsync();
        Entity = new Car();
    }

    public Task<IActionResult> OnPostAsync() => SaveOneEntityWithLookupAsync(carDataService.AddAsync);
    protected override async Task GetLookupValuesAsync() =>
        LookupValues =
        new SelectList(
            (await makeDataService.GetAllAsync()).OrderBy(m => m.Name),
            nameof(Make.Id),
            nameof(Make.Name));

}