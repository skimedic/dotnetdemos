// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Details.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DetailsModel(
    IAppLogging appLogging,
    IMakeDataService makeDataService) : BasePageModel<Make>(appLogging, makeDataService, "Details")
{
    public Task OnGetAsync(
        int? id) =>
        GetOneEntityAsync(id);
}