// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.Controllers.Base;

[Route("[controller]/[action]")]
public abstract class BaseCrudController<TEntity>(
    IAppLogging appLogging,
    IDataServiceBase<TEntity> baseDataService) : Controller where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLogging;
    protected readonly IDataServiceBase<TEntity> BaseDataServiceInstance = baseDataService;
    protected virtual Task<SelectList> GetLookupValuesAsync() => Task.FromResult<SelectList>(null);

    protected async Task<TEntity> GetOneEntityAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            return null;
        }

        return await BaseDataServiceInstance.FindAsync(id.Value);
    }

    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    [HttpGet]
    public virtual async Task<IActionResult> IndexAsync() => View(await BaseDataServiceInstance.GetAllAsync());

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DetailsAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var entity = await GetOneEntityAsync(id);
        return entity == null ? NotFound() : View(entity);
    }

    [HttpGet]
    public virtual async Task<IActionResult> CreateAsync()
    {
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> CreateAsync(
        TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            ViewData["LookupValues"] = await GetLookupValuesAsync();
            return View(entity);
        }

        var savedEntity = await BaseDataServiceInstance.AddAsync(entity);
        return RedirectToAction(nameof(DetailsAsync)
            .RemoveAsyncSuffix(), new
        {
            id = savedEntity.Id
        });
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> EditAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var entity = await GetOneEntityAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> EditAsync(
        int id,
        TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            ViewData["LookupValues"] = await GetLookupValuesAsync();
            return View(entity);
        }

        var savedEntity = await BaseDataServiceInstance.UpdateAsync(entity);
        return RedirectToAction(nameof(DetailsAsync)
            .RemoveAsyncSuffix(), new
        {
            id = savedEntity.Id
        });
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DeleteAsync(
        int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var entity = await GetOneEntityAsync(id);
        return entity == null ? NotFound() : View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> DeleteAsync(
        int id,
        TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        await BaseDataServiceInstance.DeleteAsync(entity);
        return RedirectToAction(nameof(IndexAsync)
            .RemoveAsyncSuffix());
    }
}