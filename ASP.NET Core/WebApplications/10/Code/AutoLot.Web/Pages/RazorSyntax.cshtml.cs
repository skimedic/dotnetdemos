namespace AutoLot.Web.Pages;

public class RazorSyntaxModel(
    ICarDataService carDataService,
    IMakeDataService makeDataService) : PageModel
{
    [ViewData]
    public SelectList LookupValues { get; set; }

    [ViewData] public string Title => "Razor Syntax";
    [BindProperty] public Car Entity { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var makes = (await makeDataService.GetAllAsync()).ToList();
        LookupValues = new SelectList(makes, nameof(Make.Id), nameof(Make.Name));
        Entity = await carDataService.FindAsync(6);
        return Page();
    }
}