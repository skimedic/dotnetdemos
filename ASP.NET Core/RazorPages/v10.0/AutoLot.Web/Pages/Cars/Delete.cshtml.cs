// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DeleteModel(
    ICarRepo carRepo,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carRepo, "Delete")
{
    public void OnGet(
        int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }
        GetOneEntity(id);
        Error = Entity == null ? "Not found" : string.Empty;
    }
    public IActionResult OnPost(
        int id)
    {
        if (Entity == null || id != Entity.Id)
        {
            Error = "Invalid Request";
            return Page();
        }
        var result = DeleteOne(id);
        Error = string.Empty;
        Entity = null;
        return result;
    }
}