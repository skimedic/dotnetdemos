namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class EditModel(IAppLogging appLogging, IMakeDataService makeDataService)
  : BasePageModel<Make>(appLogging, makeDataService, "Edit")
{
    public async Task OnGetAsync(int? id) => await GetOneEntityAsync(id);
    public async Task<IActionResult> OnPostAsync() => await SaveOneAsync(MainDataService.UpdateAsync);
}
