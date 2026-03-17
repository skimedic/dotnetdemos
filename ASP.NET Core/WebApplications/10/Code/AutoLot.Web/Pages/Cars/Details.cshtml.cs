namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(
    ICarDataService carDataService,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carDataService, "Details")
{
    public async Task OnGetAsync(int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
        }
        else
        {
            await GetOneEntityAsync(id);
            Error = Entity == null ? "Not found" : string.Empty;
        }
    }
}