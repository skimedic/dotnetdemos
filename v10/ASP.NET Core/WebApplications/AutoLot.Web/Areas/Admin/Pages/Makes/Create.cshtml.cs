// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class CreateModel(
    IAppLogger appLogger,
    IMakeDataService makeDataService) : BasePageModel<Make>(
    appLogger,
    makeDataService,
    "Create")
{
    public void OnGet() => Entity = new Make();
    public Task<IActionResult> OnPostAsync() => SaveOneEntityAsync(makeDataService.AddAsync);
}