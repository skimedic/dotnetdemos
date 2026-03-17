namespace AutoLot.Web.Pages.Cars;

public class CreateModel(
    ICarDataService carDataService,
    IMakeDataService makeDataService,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carDataService, "Create")
{
    public async Task OnGetAsync()
    {
        await GetLookupValuesAsync();
        Entity = new Car { IsDrivable = true };
    }

    public async Task<IActionResult> OnPostAsync()
        => await SaveOneWithLookupAsync(MainDataService.AddAsync);

    protected override async Task GetLookupValuesAsync()
        => LookupValues = new SelectList((await makeDataService.GetAllAsync()).OrderBy(m => m.Name).ToList(), nameof(Make.Id),
            nameof(Make.Name));
}