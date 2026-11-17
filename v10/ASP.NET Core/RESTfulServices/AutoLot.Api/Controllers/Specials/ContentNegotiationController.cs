// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - ContentNegotiationController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Specials;

[ApiVersionNeutral]
public class ContentNegotiationController(IAppLogger appLogger) : BaseAppController(appLogger)
{
    [HttpGet]
    [Produces(
        "application/json",
        "application/xml",
        "text/csv")]
    [ProducesResponseType<List<Driver>>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets all drivers with content negotiation.")]
    [EndpointDescription(
        "Returns all drivers in the requested format (JSON, XML, CSV). Example: GET /api/contentnegotiation. No request body required.")]
    public ActionResult<List<Driver>> Get(
        [FromServices]
        IDriverRepo driverRepo) =>
        driverRepo.GetAllAsList();
}