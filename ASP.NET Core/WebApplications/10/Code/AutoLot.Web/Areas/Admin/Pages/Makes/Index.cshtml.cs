namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class IndexModel(IAppLogging appLogging, IMakeDataService makeDataService) : PageModel
{
    [ViewData]
    public string Title => "Makes";

    public IEnumerable<Make> MakeRecords { get; set; }
    public async Task OnGetAsync() => MakeRecords = await makeDataService.GetAllAsync();
}