// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseCrudController<TEntity>(
    IAppLogging appLogging,
    IBaseRepo<TEntity> baseRepo)
    : ControllerBase where TEntity : BaseEntity, new()
{
    protected readonly IBaseRepo<TEntity> MainRepoInstance = baseRepo;
    protected readonly IAppLogging AppLoggingInstance = appLogging;

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets all entities.")]
    [EndpointDescription("Returns a list of all entities. Example: GET /api/[controller]. No request body required.")]
    public virtual ActionResult<List<TEntity>> GetAll() => Ok(MainRepoInstance.GetAllIgnoreQueryFilters().ToList());


    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [EndpointSummary("Gets a single entity by ID.")]
    [EndpointDescription("Returns the entity with the specified ID. Example: GET /api/[controller]/1. No request body required.")]
    public virtual ActionResult<TEntity> GetOne(
        [Description("The unique identifier of the entity. Required.")] int id)
    {
        var entity = MainRepoInstance.Find(id);
        return entity == null ? NoContent() : Ok(entity);
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Updates an entity by ID.")]
    [EndpointDescription("Updates the entity with the specified ID. Example: PUT /api/[controller]/1. JSON body required: { \"property\": \"value\" }")]
    public virtual ActionResult<TEntity> UpdateOne(
        [Description("The unique identifier of the entity. Required.")] int id,
        [Description("The entity to update. Required.")] TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        MainRepoInstance.Update(entity);
        return Ok(entity);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Adds a new entity.")]
    [EndpointDescription("Creates a new entity. Example: POST /api/[controller]. JSON body required: { \"property\": \"value\" }")]
    public virtual ActionResult<TEntity> AddOne(
        [Description("The entity to add. Required.")] TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        MainRepoInstance.Add(entity);
        return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Deletes an entity by ID.")]
    [EndpointDescription("Deletes the entity with the specified ID. Example: DELETE /api/[controller]/1. JSON body required: { \"id\": 1 }")]
    public virtual IActionResult DeleteOne(
        [Description("The unique identifier of the entity. Required.")] int id,
        [Description("The entity to delete. Required.")] TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        MainRepoInstance.Delete(entity);
        return Ok();
    }
}