namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DeleteModel(IAppLogging appLogging, IMakeDataService makeDataService)
  : BasePageModel<Make>(appLogging, makeDataService, "Delete")
{
    public async Task OnGetAsync(int? id) => await GetOneEntityAsync(id);
    public async Task<IActionResult> OnPostAsync(int id) => await DeleteOneAsync(id);
}
