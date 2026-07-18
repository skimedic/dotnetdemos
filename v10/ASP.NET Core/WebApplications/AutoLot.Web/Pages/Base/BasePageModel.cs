// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - BasePageModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity>(
    IAppLogging appLogging,
    IDataServiceBase<TEntity> baseDataService,
    string pageTitle) : PageModel where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLogging;
    protected readonly IDataServiceBase<TEntity> BaseDataServiceInstance = baseDataService;

    [ViewData]
    public string Title { get; init; } = pageTitle;

    [BindProperty]
    public TEntity Entity { get; set; }

    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected virtual Task GetLookupValuesAsync()
    {
        LookupValues = null;
        return Task.CompletedTask;
    }

    protected virtual async Task GetOneEntityAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }

        Entity = await BaseDataServiceInstance.FindAsync(id.Value);
        Error = Entity == null ? "Not found" : string.Empty;
    }

    protected virtual async Task<IActionResult> SaveOneEntityAsync(
        Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var savedEntity = await saveFunction(Entity, true);
        return RedirectToPage("Details", new
        {
            id = savedEntity.Id
        });
    }

    protected virtual async Task<IActionResult> SaveOneEntityWithLookupAsync(
        Func<TEntity, bool, Task<TEntity>> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync();
            return Page();
        }

        var savedEntity = await saveFunction(Entity, true);
        return RedirectToPage("Details", new
        {
            id = savedEntity.Id
        });
    }

    protected virtual async Task<IActionResult> DeleteOneEntityAsync(
        int id)
    {
        if (Entity == null || Entity.Id != id)
        {
            Error = "Invalid Request";
            return BadRequest();
        }

        await BaseDataServiceInstance.DeleteAsync(Entity);
        Error = string.Empty;
        return RedirectToPage("Index");
    }
}