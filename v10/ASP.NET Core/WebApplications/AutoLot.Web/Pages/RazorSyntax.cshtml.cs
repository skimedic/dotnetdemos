// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - RazorSyntax.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages;

public class RazorSyntaxModel(
    ICarDataService carDataService,
    IMakeDataService makeDataService) : PageModel
{
    [ViewData]
    public SelectList LookupValues { get; set; }

    [ViewData]
    public string Title => "Razor Syntax";

    [BindProperty]
    public Car Entity { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        LookupValues =
        new(
            await makeDataService.GetAllAsync(),
            nameof(Make.Id),
            nameof(Make.Name));
        Entity = await carDataService.FindAsync(6);
        return Page();
    }
}