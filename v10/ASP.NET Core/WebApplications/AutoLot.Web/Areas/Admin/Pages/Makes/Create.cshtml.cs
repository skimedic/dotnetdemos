// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class CreateModel(
    IAppLogging appLogging,
    IMakeDataService makeDataService) : BasePageModel<Make>(appLogging, makeDataService, "Create")
{
    public void OnGet() => Entity = new Make();

    public Task<IActionResult> OnPostAsync() => SaveOneEntityAsync(makeDataService.AddAsync);
}
