// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - ContentNegotiationController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[ApiVersionNeutral]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ContentNegotiationController : ControllerBase
{
    [HttpGet]
    [Produces("application/json", "application/xml", "text/csv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets all drivers with content negotiation.")]
    [EndpointDescription(
        "Returns all drivers in the requested format (JSON, XML, CSV). Example: GET /api/contentnegotiation. No request body required.")]
    public IActionResult Get(
        [FromServices]
        IDriverRepo driverRepo) =>
        Ok(driverRepo.GetAllAsList());
}