namespace AutoLot.Web.Pages.Cars;

public class EditModel(
    ICarDataService carDataService,
    IMakeDataService makeDataService,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carDataService, "Edit")
{
    public async Task OnGetAsync(int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }
        await GetOneEntityAsync(id);
        await GetLookupValuesAsync();
        Error = Entity == null ? "Not found" : string.Empty;
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (Entity == null || id != Entity.Id)
        {
            Error = "Invalid Request";
            return Page();
        }

        var result = await SaveOneWithLookupAsync(MainDataService.UpdateAsync);
        Error = string.Empty;
        return result;
    }

    protected override async Task GetLookupValuesAsync()
        => LookupValues = new SelectList((await makeDataService.GetAllAsync()).OrderBy(m => m.Name).ToList(), nameof(Make.Id),
            nameof(Make.Name));
}