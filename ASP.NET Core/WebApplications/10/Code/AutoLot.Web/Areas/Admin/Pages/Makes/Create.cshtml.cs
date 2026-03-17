namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class CreateModel(IAppLogging appLogging, IMakeDataService makeDataService)
  : BasePageModel<Make>(appLogging, makeDataService, "Create")
{
    public void OnGet() => Entity = new Make();
    public async Task<IActionResult> OnPostAsync() => await SaveOneAsync(MainDataService.AddAsync);
}
