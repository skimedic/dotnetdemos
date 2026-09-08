// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DetailsModel(
    IAppLogger appLogger,
    IMakeDataService makeDataService) : BasePageModel<Make>(
    appLogger,
    makeDataService,
    "Details")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);
}