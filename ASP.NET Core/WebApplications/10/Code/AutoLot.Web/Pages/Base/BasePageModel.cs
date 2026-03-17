namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity>(
    IAppLogging appLoggingInstance,
    IDataServiceBase<TEntity> mainDataService,
    string pageTitle) : PageModel
    where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLoggingInstance;
    protected readonly IDataServiceBase<TEntity> MainDataService = mainDataService;

    [ViewData] public string Title { get; init; } = pageTitle;

    [BindProperty] public TEntity Entity { get; set; }
    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected virtual Task GetLookupValuesAsync() => Task.Run(() => LookupValues = null);

    protected virtual async Task GetOneEntityAsync(int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }

        Entity = await MainDataService.FindAsync(id.Value);
        Error = Entity == null ? "Not found" : string.Empty;
    }

    protected virtual async Task<IActionResult> SaveOneAsync(Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _ = await saveFunction(Entity, true);
        return RedirectToPage("Details", new { id = Entity.Id});
    }

    protected virtual async Task<IActionResult> SaveOneWithLookupAsync(Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync();
            return Page();
        }

        _ = await saveFunction(Entity, true);
        return RedirectToPage("Details", new { id = Entity.Id });
    }

    protected virtual async Task<IActionResult> DeleteOneAsync(int id)
    {
        await MainDataService.DeleteAsync(Entity);
        return RedirectToPage("Index");
    }
}