// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DeleteModel(
    IAppLogger appLogger,
    IMakeDataService makeDataService) : BasePageModel<Make>(
    appLogger,
    makeDataService,
    "Delete")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);

    public Task<IActionResult> OnPostAsync(
        int id) =>
        DeleteOneEntityAsync(id);
}