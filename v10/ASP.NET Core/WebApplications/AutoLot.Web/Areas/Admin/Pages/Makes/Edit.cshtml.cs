// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class EditModel(
    IAppLogging appLogging,
    IMakeDataService makeDataService) : BasePageModel<Make>(appLogging, makeDataService, "Edit")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);

    public Task<IActionResult> OnPostAsync() => SaveOneEntityAsync(makeDataService.UpdateAsync);
}