namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DetailsModel(
    IAppLogging appLogging,
    IMakeDataService makeDataService)
    : BasePageModel<Make>(appLogging, makeDataService, "Details")
{
    public async Task OnGetAsync(
        int? id) => await GetOneEntityAsync(id);
}