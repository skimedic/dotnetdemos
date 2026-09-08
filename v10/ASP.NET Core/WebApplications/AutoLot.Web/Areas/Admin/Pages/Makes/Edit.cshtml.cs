// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class EditModel(
    IAppLogger appLogger,
    IMakeDataService makeDataService) : BasePageModel<Make>(
    appLogger,
    makeDataService,
    "Edit")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);

    public Task<IActionResult> OnPostAsync() => SaveOneEntityAsync(makeDataService.UpdateAsync);
}