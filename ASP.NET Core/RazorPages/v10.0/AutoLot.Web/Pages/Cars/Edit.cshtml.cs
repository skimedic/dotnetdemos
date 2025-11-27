// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class EditModel(
    ICarRepo carRepo,
    IMakeRepo makeRepo,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carRepo, "Edit")
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
        GetLookupValues();
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
        var result = SaveOneWithLookup(BaseRepoInstance.Update);
        Error = string.Empty;
        return result;
    }

    protected override void GetLookupValues()
        => LookupValues = new SelectList(makeRepo.GetAll().OrderBy(m => m.Name).ToList(), nameof(Make.Id),
            nameof(Make.Name));
}