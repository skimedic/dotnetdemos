// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - BasePageModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity>(
    IAppLogging appLoggingInstance,
    IBaseRepo<TEntity> baseRepoInstance,
    string pageTitle) : PageModel
    where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLoggingInstance;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance = baseRepoInstance;

    [ViewData] public string Title { get; init; } = pageTitle;

    [BindProperty] public TEntity Entity { get; set; }
    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected virtual void GetLookupValues() => LookupValues = null;

    protected virtual void GetOneEntity(
        int? id)
    {
        if (!id.HasValue)
        {
            Entity = null;
            Error = "Invalid Request";
            return;
        }
        Entity = BaseRepoInstance.Find(id.Value);
        Error = Entity == null ? "Not found" : string.Empty;
    }

    protected virtual IActionResult SaveOne(
        Func<TEntity, bool, TEntity> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _ = saveFunction(Entity, true);
        return RedirectToPage("Details", new { id = Entity.Id});
        }

    protected virtual IActionResult SaveOneWithLookup(
        Func<TEntity, bool, int> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            GetLookupValues();
            return Page();
        }

        _ = saveFunction(Entity, true);
        return RedirectToPage("Details", new { id = Entity.Id });
    }

    protected virtual IActionResult DeleteOne(
        int id)
        {
            //throw new Exception("Test");
            BaseRepoInstance.Delete(Entity);
        return RedirectToPage("Index");
    }
}