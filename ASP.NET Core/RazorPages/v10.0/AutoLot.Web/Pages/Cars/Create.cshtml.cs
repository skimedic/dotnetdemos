// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class CreateModel(
    ICarRepo carRepo,
    IMakeRepo makeRepo,
    IAppLogging appLogging) : BasePageModel<Car>(appLogging, carRepo, "Create")
{
    public void OnGet()
    {
        GetLookupValues();
        Entity = new Car { IsDrivable = true };
    }
    public IActionResult OnPost()
        => SaveOneWithLookup(BaseRepoInstance.Add);
    protected override void GetLookupValues()
        => LookupValues = new SelectList(makeRepo.GetAll().OrderBy(m => m.Name).ToList(), nameof(Make.Id),
            nameof(Make.Name));
}
