// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DeleteModel(
    IAppLogging appLogging,
    IMakeDataService makeDataService) : BasePageModel<Make>(appLogging, makeDataService, "Delete")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);

    public Task<IActionResult> OnPostAsync(
        int id) =>
        DeleteOneEntityAsync(id);
}