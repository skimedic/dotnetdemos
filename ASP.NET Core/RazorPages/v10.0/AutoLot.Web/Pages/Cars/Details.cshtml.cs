// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DetailsModel(
    ICarRepo carRepo,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carRepo, "Details")
{
    public void OnGet(
        int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
        }
        else
        {
            GetOneEntity(id);
            Error = Entity == null ? "Not found" : string.Empty;
        }
    }
}