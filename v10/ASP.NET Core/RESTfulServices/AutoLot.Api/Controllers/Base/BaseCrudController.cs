// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Base;

/// <summary>
///     Abstract base controller providing generic CRUD operations for entities.
/// </summary>
/// <typeparam name="TEntity">The entity type, must inherit from BaseEntity and have a parameterless constructor.</typeparam>
public abstract class BaseCrudController<TEntity>(
    IAppLogger appLogger,
    IBaseRepo<TEntity> baseRepo) : BaseAppController where TEntity : BaseEntity, new()
{
    protected readonly IAppLogger AppLoggerInstance = appLogger;
    protected readonly IBaseRepo<TEntity> MainRepoInstance = baseRepo;

    /// <summary>
    ///     Gets all entities.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Gets all entities.")]
    [EndpointDescription("Returns a list of all entities. Example: GET /api/[controller]. No request body required.")]
    public ActionResult<IEnumerable<TEntity>> GetAll() => Ok(MainRepoInstance.GetAllAsList());

    /// <summary>
    ///     Gets a single entity by ID.
    /// </summary>
    /// <param name="id">The entity ID.</param>
    /// <returns>The entity if found; otherwise NotFound.</returns>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Gets a single entity by ID.")]
    [EndpointDescription(
        "Returns the entity with the specified ID. Example: GET /api/[controller]/1. No request body required.")]
    public ActionResult<TEntity> GetOne(
        [Description("The unique identifier of the entity. Required.")]
        int id)
    {
        var entity = MainRepoInstance.Find(id);
        return entity == null ? NotFound() : Ok(entity);
    }

    /// <summary>
    ///     Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The created entity with a 201 Created response.</returns>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [EndpointSummary("Adds a new entity.")]
    [EndpointDescription(
        "Creates a new entity. Example: POST /api/[controller]. JSON body required: { \"property\": \"value\" }")]
    public ActionResult<TEntity> AddOne(
        [Description("The entity to add. Required.")]
        TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        MainRepoInstance.Add(entity);
        return CreatedAtAction(
            nameof(GetOne),
            new { id = entity.Id },
            entity);
    }

    /// <summary>
    ///     Updates an existing entity.
    /// </summary>
    /// <param name="id">The entity ID from the route.</param>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity if successful; BadRequest if ID mismatch; ValidationProblem if invalid model.</returns>
    [HttpPut("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Updates an entity by ID.")]
    [EndpointDescription(
        "Updates the entity with the specified ID. Example: PUT /api/[controller]/1. JSON body required: { \"property\": \"value\" }")]
    public ActionResult<TEntity> UpdateOne(
        [Description("The unique identifier of the entity. Required.")]
        int id,
        [Description("The entity to update. Required.")]
        TEntity entity)
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

    /// <summary>
    ///     Deletes an entity by ID.
    /// </summary>
    /// <param name="id">The entity ID from the route.</param>
    /// <param name="entity">The entity to delete (for ID verification).</param>
    /// <returns>NoContent if successful; BadRequest if ID mismatch.</returns>
    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [EndpointSummary("Deletes an entity by ID.")]
    [EndpointDescription(
        "Deletes the entity with the specified ID. Example: DELETE /api/[controller]/1. JSON body required: { \"id\": 1 }")]
    public ActionResult DeleteOne(
        [Description("The unique identifier of the entity. Required.")]
        int id,
        [Description("The entity to delete. Required.")]
        TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        MainRepoInstance.Delete(entity);
        return NoContent();
    }
}