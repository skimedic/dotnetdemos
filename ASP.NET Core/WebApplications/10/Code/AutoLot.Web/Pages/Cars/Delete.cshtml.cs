namespace AutoLot.Web.Pages.Cars;

public class DeleteModel(
    ICarDataService carDataService,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carDataService, "Delete")
{
    public async Task OnGetAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }

        await GetOneEntityAsync(id);
        Error = Entity == null ? "Not found" : string.Empty;
    }

    public async Task<IActionResult> OnPostAsync(
        int id)
    {
        if (Entity == null || id != Entity.Id)
        {
            Error = "Invalid Request";
            return Page();
        }

        var result = await DeleteOneAsync(id);
        Error = string.Empty;
        Entity = null;
        return result;
    }
}